namespace JiraLike.Api.Middlewares
{
    using Microsoft.CodeAnalysis.Operations;
    using System.Net;
    using System.Text.Json;

    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
              _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext _context)
        {
            try
            {
                await _next(_context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception ocurred");
                await HandlerExceptionAsync(_context, ex);

            }

        }
        private static Task HandlerExceptionAsync(HttpContext httpContext, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string message = "An unexpected error occurred.";

            //Custom Exception Mapping
            switch(exception)
            {
                case UnauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized;
                    message = "Unauthorized Access";
                    break;

                case ArgumentException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;
                case KeyNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    message = "Resource Not Found";
                    break;

            }
            var response = new
            {
                error = message,
                statusCode = (int)statusCode
            };
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)statusCode;

            return httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

    }
}

