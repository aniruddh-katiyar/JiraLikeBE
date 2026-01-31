namespace JiraLike.Api.Extension
{
    using Serilog;

    /// <summary>
    /// 
    /// </summary>
    public static class LoggingExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddLogging(this IServiceCollection services)
        {
            services.AddLogging(lb => lb.AddSerilog(dispose: true));
            return services;
        }
    }
}
