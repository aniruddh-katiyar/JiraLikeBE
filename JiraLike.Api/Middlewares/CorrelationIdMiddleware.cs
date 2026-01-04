using Microsoft.AspNetCore.Http;
using Serilog.Context;

public class CorrelationIdMiddleware
{
    private const string HeaderName = "X-Correlation-Id";
    private readonly RequestDelegate _next;

    public CorrelationIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // 1️⃣ Read incoming CorrelationId OR create new
        var correlationId = context.Request.Headers.ContainsKey(HeaderName)
            ? context.Request.Headers[HeaderName].ToString()
            : Guid.NewGuid().ToString();

        // 2️⃣ Store it for the entire request
        context.TraceIdentifier = correlationId;
        context.Items[HeaderName] = correlationId;

        // 3️⃣ Add to response headers
        context.Response.Headers[HeaderName] = correlationId;

        // 4️⃣ Push into Serilog context
        using (LogContext.PushProperty("CorrelationId", correlationId))
        {
            await _next(context);
        }
    }
}
