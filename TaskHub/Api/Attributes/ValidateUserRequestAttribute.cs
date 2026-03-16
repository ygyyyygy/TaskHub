using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace Api.Attributes;

public class ValidateUserRequestAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.ActionArguments.FirstOrDefault(x => 
            x.Value?.GetType().Name == "CreateUserRequest" || 
            x.Value?.GetType().Name == "SetUserNameRequest").Value;

        if (request == null)
        {
            context.Result = new BadRequestObjectResult("Тело запроса отсутствует");
            return;
        }

        var nameProperty = request.GetType().GetProperty("Name", BindingFlags.Public | BindingFlags.Instance);
        
        if (nameProperty == null)
        {
            base.OnActionExecuting(context);
            return;
        }

        var nameValue = nameProperty.GetValue(request) as string;

        if (string.IsNullOrWhiteSpace(nameValue))
        {
            context.Result = new BadRequestObjectResult("Имя пользователя не задано");
            return;
        }

        base.OnActionExecuting(context);
    }
}