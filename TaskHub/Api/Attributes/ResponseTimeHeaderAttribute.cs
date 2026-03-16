using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Api.Attributes;

public class ResponseTimeHeaderAttribute : ActionFilterAttribute
{
    private readonly Stopwatch _stopwatch = new();

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch.Start();
        base.OnActionExecuting(context);
    }

    public override void OnResultExecuting(ResultExecutingContext context)
    {
        context.HttpContext.Response.OnStarting(() =>
        {
            _stopwatch.Stop();
            var elapsedMs = _stopwatch.ElapsedMilliseconds;
            context.HttpContext.Response.Headers.Append("X-Response-Time-Ms", elapsedMs.ToString());
            return Task.CompletedTask;
        });

        base.OnResultExecuting(context);
    }
}