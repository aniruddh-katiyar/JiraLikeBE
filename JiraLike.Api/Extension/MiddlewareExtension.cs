namespace JiraLike.Api.Extension
{
    using JiraLike.Api.Middlewares;
    using Serilog;

    /// <summary>
    /// 
    /// </summary>
    public static class MiddlewareExtension 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationBuilder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<CorrelationIdMiddleware>();

            applicationBuilder.UseMiddleware<GlobalExceptionMiddleware>();

            applicationBuilder.UseSerilogRequestLogging();

            return applicationBuilder;
        }
    }
}
