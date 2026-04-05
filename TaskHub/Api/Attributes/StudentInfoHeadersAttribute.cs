using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Api.Middleware;

namespace Api.Attributes;

public class StudentInfoHeadersAttribute : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        var studentInfo = context.HttpContext.RequestServices.GetService<StudentInfo>();
        
        if (studentInfo != null)
        {
            context.HttpContext.Response.OnStarting(() =>
            {
                context.HttpContext.Response.Headers.Append("X-Student-Name", studentInfo.Name);
                context.HttpContext.Response.Headers.Append("X-Student-Group", studentInfo.Group);
                return Task.CompletedTask;
            });
        }

        base.OnResultExecuting(context);
    }
}