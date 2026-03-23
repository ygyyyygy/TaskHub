using Logic.UserTasks.Models;

namespace Logic.UserTasks.Services.Interfaces;

/// <summary>
/// Сервис управления задачами пользователей
/// </summary>
public interface IUserTaskService
{
    Task<UserTaskModel> CreateUserTaskAsync(string title, Guid createdByUserId, CancellationToken cancellationToken);
    Task<List<UserTaskModel>> GetAllUserTasksAsync(CancellationToken cancellationToken);
    Task<UserTaskModel?> GetUserTaskByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> SetUserTaskTitleAsync(Guid id, string title, CancellationToken cancellationToken);
    Task<bool> DeleteUserTaskByIdAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteAllUserTasksAsync(CancellationToken cancellationToken);
}