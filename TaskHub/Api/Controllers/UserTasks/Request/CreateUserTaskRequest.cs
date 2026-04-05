using System.Text.Json.Serialization;

namespace Api.Controllers.UserTasks.Request;

/// <summary>
/// Запрос на создание задачи пользователя
/// </summary>
public record CreateUserTaskRequest
{
    /// <summary>
    /// Название задачи
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; init; }
    
    /// <summary>
    /// Идентификатор пользователя, создающего задачу
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Guid? UserId { get; init; }
}