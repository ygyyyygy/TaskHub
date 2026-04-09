using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace Api.ModelBinders;

/// <summary>
/// Атрибут для проверки id задачи в маршруте
/// </summary>
public class FromRouteTaskIdAttribute : ModelBinderAttribute
{
    public FromRouteTaskIdAttribute() : base(typeof(TaskIdModelBinder))
    {
        Name = "id";
        BindingSource = BindingSource.Path;
    }
}

/// <summary>
/// ModelBinder для проверки id задачи
/// </summary>
public class TaskIdModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var valueProviderResult = bindingContext.ValueProvider.GetValue("id");

        if (string.IsNullOrEmpty(valueProviderResult.FirstValue))
        {
            bindingContext.ModelState.AddModelError("id", "Идентификатор задачи не задан");
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }
        
        var idString = valueProviderResult.FirstValue!;
        
        if (!Guid.TryParse(idString, out var guidValue))
        {
            bindingContext.ModelState.AddModelError("id", "Идентификатор задачи имеет некорректный формат");
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }
        
        bindingContext.Result = ModelBindingResult.Success(guidValue);
        return Task.CompletedTask;
    }
}