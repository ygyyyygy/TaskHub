namespace Logic.UserTasks.Models;

/// <summary>
/// Модель задачи пользователя (бизнес-слой)
/// </summary>
public class UserTaskModel
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public Guid CreatedByUserId { get; set; }
    public DateTimeOffset CreatedUtc { get; set; }
}