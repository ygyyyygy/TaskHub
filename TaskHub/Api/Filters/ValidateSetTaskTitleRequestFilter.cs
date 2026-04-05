using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Api.Controllers.UserTasks.Request;

namespace Api.Filters;

/// <summary>
/// Фильтр для валидации запроса изменения названия задачи пользователя
/// </summary>
public class ValidateSetUserTaskTitleRequestFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.ActionArguments.Values.OfType<SetUserTaskTitleRequest>().FirstOrDefault();
        
        if (request == null || !context.ActionArguments.ContainsKey("request"))
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }
        
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            context.Result = new BadRequestObjectResult("Название задачи не задано");
            return;
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}