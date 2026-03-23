namespace Api.Controllers.UserTasks.Response;

/// <summary>
/// Ответ с данными задачи пользователя
/// </summary>
public record UserTaskResponse
{
    public Guid Id { get; }
    public string? Title { get; }
    public Guid CreatedByUserId { get; }
    public DateTimeOffset CreatedUtc { get; }

    public UserTaskResponse(Guid id, string? title, Guid createdByUserId, DateTimeOffset createdUtc)
    {
        Id = id;
        Title = title;
        CreatedByUserId = createdByUserId;
        CreatedUtc = createdUtc;
    }
}