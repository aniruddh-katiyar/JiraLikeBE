namespace JiraLike.Api
{
    using JiraLike.Api.Middlewares;
    using JiraLike.Application.Handler.Users;
    using JiraLike.Application.Interfaces;
    using JiraLike.Application.Mapper;
    using JiraLike.Application.Resolvers;
    using JiraLike.Domain.Entities;
    using JiraLike.Infrastructure.Ai;
    using JiraLike.Infrastructure.DbContexts;
    using JiraLike.Infrastructure.Repository;
    using JiraLike.Infrastructure.TokenGenerator;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using Serilog;
    using System.Reflection;
    using System.Text;

    public sealed class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // ------------------------
            // Logging
            // ------------------------
            services.AddLogging(lb => lb.AddSerilog(dispose: true));

            // ------------------------
            // Swagger
            // ------------------------
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JiraLike API",
                    Version = "v1"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<JiraLikeDbContext>(options =>
            {
                var dbPath = _environment.IsEnvironment("Docker")
                    ? "/app/data/jiralike.db"
                    : Path.Combine(AppContext.BaseDirectory, "jiralike.db");

                options.UseSqlite($"Data Source={dbPath}");
            });

            // services.AddScoped<KnowledgeService>();
            // services.AddScoped<ChatService>();
            services.AddScoped<ImproveDescriptionService>();
            services.AddHttpClient<IAiService, AiService>();


            // ------------------------
            // Repositories & Core Services
            // ------------------------
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();
            services.AddHttpContextAccessor();

            services.AddScoped<IUserInformationResolver, UserInformationResolver>();

            services.AddAutoMapper(typeof(UserMapper));

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<UserMapper>();

                cfg.ShouldMapMethod = method =>
                    method.DeclaringType.Namespace == null ||
                    !method.DeclaringType.Namespace.StartsWith("System.Linq");
            });


            // ------------------------
            // MediatR
            // ------------------------
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreateUserHandler).Assembly));

            // ------------------------
            // Authentication & Authorization
            // ------------------------
            var secretKey = _configuration["Jwt:SecretKey"]
                ?? throw new InvalidOperationException("JWT SecretKey missing");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
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
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(secretKey))
                    };
                });

            services.AddAuthorization();

            // ------------------------
            // CORS
            // ------------------------
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            // ------------------------
            // Database Migration
            // ------------------------
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<JiraLikeDbContext>();
                dbContext.Database.Migrate();
            }

            app.UseRouting();

            // ------------------------
            // Swagger
            // ------------------------
            app.UseSwagger();
            app.UseSwaggerUI();

            // ------------------------
            // Middleware Pipeline
            // ------------------------
            app.UseMiddleware<CorrelationIdMiddleware>();
            app.UseMiddleware<GlobalExceptionMiddleware>();

            app.UseSerilogRequestLogging();

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
