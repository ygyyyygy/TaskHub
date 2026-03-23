namespace Api.Controllers.UserTasks.Request;

/// <summary>
/// Запрос на создание задачи пользователя
/// </summary>
public record CreateUserTaskRequest
{
    /// <summary>
    /// Название задачи
    /// </summary>
    public required string Title { get; init; }
}