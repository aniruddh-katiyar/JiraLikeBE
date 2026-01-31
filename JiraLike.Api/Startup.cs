namespace JiraLike.Api
{
    using JiraLike.Api.Extension;
    using JiraLike.Api.Hubs;
    using JiraLike.Api.Notifier;
    using JiraLike.Application.Extension;
    using JiraLike.Application.Interfaces;
    using JiraLike.Infrastructure.Extension;

    /// <summary>
    /// 
    /// </summary>
    public sealed class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="environment"></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddLogging();

            services.AddSignalR();

            services.AddSwaggerDocumentation();

            services.AddScoped<ImproveDescriptionService>();

            services.AddScoped<ISignalRActivityNotifier, SignalRActivityNotifier>();

            services.AddApplication();

            services.AddSecurity(_configuration);

            services.AddInfrastructure(_configuration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="environment"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            app.UseRouting();

            app.UseSecurity();

            app.UserSwaggerDocumentation();

            app.UseInfrastructure(environment);

            app.UseMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ActivityHub>("/api/activityHub");
            });

        }
    }
}
