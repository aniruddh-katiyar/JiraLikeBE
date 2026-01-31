namespace JiraLike.Infrastructure.Extension
{
    using JiraLike.Application.Interfaces;
    using JiraLike.Application.Interfaces.Repository;
    using JiraLike.Infrastructure.Ai;
    using JiraLike.Infrastructure.DbContexts;
    using JiraLike.Infrastructure.Repositories;
    using JiraLike.Infrastructure.Repository;
    using JiraLike.Infrastructure.Token;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddDbContext<JiraLikeDbContext>(options =>
                             options.UseNpgsql(_configuration.GetConnectionString("PostgresDb")));

            services.AddHttpClient<IAiService, AiService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<ITokenGenerator, TokenGenerator>();

            services.AddScoped<IReadDbContext, ReadDbContext>();

            services.AddScoped<IIssueRepository, IssueRepository>();

            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<JiraLikeDbContext>();

                if (webHostEnvironment.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }
            }
            return applicationBuilder;
        }
    }
}
