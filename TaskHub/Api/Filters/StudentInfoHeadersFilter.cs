using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Api.Middleware;

namespace Api.Filters;

/// <summary>
/// Фильтр для добавления информации о студенте в заголовки ответа
/// </summary>
public class StudentInfoHeadersFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var result = await next();
        
        var studentInfo = context.HttpContext.RequestServices.GetService<StudentInfo>();
        
        if (studentInfo != null && result.Exception == null)
        {
            context.HttpContext.Response.OnStarting(() =>
            {
                context.HttpContext.Response.Headers.Append("X-Student-Name", studentInfo.Name);
                context.HttpContext.Response.Headers.Append("X-Student-Group", studentInfo.Group);
                return Task.CompletedTask;
            });
        }
    }
}