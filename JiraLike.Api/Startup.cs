
namespace JiraLike.Api
{
    using JiraLike.Application.Abstraction.Services;
    using JiraLike.Application.Handler.Users;
    using JiraLike.Application.Mapper;
    using JiraLike.Application.Services;
    using JiraLike.Domain.Entities;
    using JiraLike.Infrastructure.DbContexts;
    using JiraLike.Infrastructure.Repository;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using Serilog;
    using System.Text;

    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Controllers
            services.AddControllers();

            //Logging
            services.AddSerilog();
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog(dispose: true);
            });

            // Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "JiraLike API",
                    Version = "v1"
                });
            });

            // Database
            services.AddDbContext<JiraLikeDbContext>(options =>
                options.UseSqlServer(
                    _configuration.GetConnectionString("DbConnection")));

            // Repositories & Services
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();
            services.AddScoped<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();

            // JWT Authentication
            var secretKey = _configuration["Jwt:SecretKey"]
                ?? throw new InvalidOperationException("JWT SecretKey is missing");

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = _configuration["Jwt:Issuer"],
                        ValidAudience = _configuration["Jwt:Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });

            services.AddAuthorization();

            // AutoMapper
            services.AddAutoMapper(cfg =>
            {
                cfg.ShouldMapMethod = _ => false;
                cfg.ShouldMapProperty = p => p.GetMethod?.IsPublic == true;
            }, typeof(UserMapper));

            // MediatR
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreateUserHandler).Assembly));

            // CORS (Angular)
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        //Pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            // ✅ MUST BE FIRST (before Serilog logging)
            app.UseMiddleware<CorrelationIdMiddleware>();

            // ✅ Now Serilog can read CorrelationId
            app.UseSerilogRequestLogging(options =>
            {
                options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                {
                    diagnosticContext.Set(
                        "CorrelationId",
                        httpContext.TraceIdentifier
                    );
                };
            });

            app.UseHttpsRedirection();
          

            app.UseRouting();

            app.UseCors("AllowAngular");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
