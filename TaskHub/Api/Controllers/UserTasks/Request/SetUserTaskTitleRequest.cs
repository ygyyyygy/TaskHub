namespace Api.Controllers.UserTasks.Request;

/// <summary>
/// Запрос на изменение названия задачи
/// </summary>
public record SetUserTaskTitleRequest
{
    /// <summary>
    /// Новое название задачи
    /// </summary>
    public string? Title { get; init; }
}