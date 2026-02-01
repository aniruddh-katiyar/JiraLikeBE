namespace JiraLike.Api.Extension
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;

    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public static class AuthenticationExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="_configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", policy =>
                {
                    policy
                        .WithOrigins("http://localhost:4200", "https://jiralike.vercel.app")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials(); // REQUIRED for SignalR
                });
            });

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
            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationBuilder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSecurity(this IApplicationBuilder applicationBuilder)
        {

            applicationBuilder.UseCors("AllowAngular");

            applicationBuilder.UseAuthentication();

            applicationBuilder.UseAuthorization();

            return applicationBuilder;
        }
    }
}
