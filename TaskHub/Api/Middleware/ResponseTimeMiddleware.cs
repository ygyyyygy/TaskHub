using System.Diagnostics;

namespace Api.Middleware;

/// <summary>
/// Middleware для измерения времени обработки запроса
/// </summary>
public class ResponseTimeMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ResponseTimeMiddleware> _logger;

    public ResponseTimeMiddleware(RequestDelegate next, ILogger<ResponseTimeMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        
        context.Response.OnStarting(() =>
        {
            stopwatch.Stop();
            
            var elapsedMs = stopwatch.ElapsedMilliseconds;
            context.Response.Headers.Append("X-Response-Time-Ms", elapsedMs.ToString());
            
            _logger.LogDebug("Request {Method} {Path} completed in {ElapsedMs}ms", 
                context.Request.Method, context.Request.Path, elapsedMs);
            
            return Task.CompletedTask;
        });
        
        await _next(context);
    }
}