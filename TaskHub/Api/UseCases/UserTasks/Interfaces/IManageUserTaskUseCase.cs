using Api.Controllers.UserTasks.Response;

namespace Api.UseCases.UserTasks.Interfaces;

/// <summary>
/// UseCase управления задачами пользователей
/// </summary>
public interface IManageUserTaskUseCase
{
    Task<UserTaskResponse> CreateUserTaskAsync(string title, Guid createdByUserId, CancellationToken cancellationToken);
    Task<UserTaskListResponse> GetAllUserTasksAsync(CancellationToken cancellationToken);
    Task<UserTaskResponse?> GetUserTaskByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> SetUserTaskTitleAsync(Guid id, string title, CancellationToken cancellationToken);
    Task<bool> DeleteUserTaskByIdAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteAllUserTasksAsync(CancellationToken cancellationToken);
}