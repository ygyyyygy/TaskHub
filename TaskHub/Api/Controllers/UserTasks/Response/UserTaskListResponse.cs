namespace Api.Controllers.UserTasks.Response;

/// <summary>
/// Ответ со списком задач пользователя
/// </summary>
public record UserTaskListResponse
{
    public IReadOnlyCollection<UserTaskResponse> TaskList { get; init; }

    public UserTaskListResponse(IReadOnlyCollection<UserTaskResponse> taskList)
    {
        TaskList = taskList;
    }
}