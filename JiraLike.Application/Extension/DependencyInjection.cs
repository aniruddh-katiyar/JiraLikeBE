namespace JiraLike.Application.Extension
{
    using JiraLike.Application.Handler.Users;
    using JiraLike.Application.Interfaces;
    using JiraLike.Application.Mapper;
    using JiraLike.Application.Resolvers;
    using JiraLike.Domain.Entities;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserMapper));

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<UserMapper>();

                cfg.ShouldMapMethod = method =>
                    method.DeclaringType.Namespace == null ||
                    !method.DeclaringType.Namespace.StartsWith("System.Linq");
            });


           
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreateUserHandler).Assembly));
           

            services.AddScoped<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();
            services.AddHttpContextAccessor();
          

            services.AddScoped<IUserInformationResolver, UserInformationResolver>();
            return services;
        }

    }
}
