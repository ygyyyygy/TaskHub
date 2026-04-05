using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Api.Filters;

/// <summary>
/// Фильтр для логирования запросов
/// </summary>
public class RequestLoggingFilter : IAsyncActionFilter
{
    private readonly ILogger<RequestLoggingFilter> _logger;

    public RequestLoggingFilter(ILogger<RequestLoggingFilter> logger)
    {
        _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var httpMethod = context.HttpContext.Request.Method;
        var path = context.HttpContext.Request.Path;
        
        _logger.LogInformation("Начало выполнения запроса: {Method} {Path}", httpMethod, path);
        
        var stopwatch = Stopwatch.StartNew();
        var result = await next();
        stopwatch.Stop();
        
        var statusCode = context.HttpContext.Response.StatusCode;
        
        _logger.LogInformation("Завершение запроса: {Method} {Path} -> {StatusCode} за {ElapsedMs} мс", 
            httpMethod, path, statusCode, stopwatch.ElapsedMilliseconds);
    }
}