using Logic.UserTasks.Models;
using Logic.UserTasks.Services.Interfaces;
using Logic.UserTasks.UseCases;

namespace Logic.UserTasks.Services;

/// <summary>
/// Реализация сервиса управления задачами пользователей
/// </summary>
public class UserTaskService : IUserTaskService
{
    private readonly CreateUserTaskUseCase _createUserTaskUseCase;
    private readonly GetUserTasksUseCase _getUserTasksUseCase;
    private readonly GetUserTaskUseCase _getUserTaskUseCase;
    private readonly SetUserTaskTitleUseCase _setUserTaskTitleUseCase;
    private readonly DeleteUserTaskUseCase _deleteUserTaskUseCase;
    private readonly DeleteUserTasksUseCase _deleteUserTasksUseCase;

    public UserTaskService(
        CreateUserTaskUseCase createUserTaskUseCase,
        GetUserTasksUseCase getUserTasksUseCase,
        GetUserTaskUseCase getUserTaskUseCase,
        SetUserTaskTitleUseCase setUserTaskTitleUseCase,
        DeleteUserTaskUseCase deleteUserTaskUseCase,
        DeleteUserTasksUseCase deleteUserTasksUseCase)
    {
        _createUserTaskUseCase = createUserTaskUseCase;
        _getUserTasksUseCase = getUserTasksUseCase;
        _getUserTaskUseCase = getUserTaskUseCase;
        _setUserTaskTitleUseCase = setUserTaskTitleUseCase;
        _deleteUserTaskUseCase = deleteUserTaskUseCase;
        _deleteUserTasksUseCase = deleteUserTasksUseCase;
    }

    public async Task<UserTaskModel> CreateUserTaskAsync(string title, Guid createdByUserId, CancellationToken cancellationToken)
    {
        return await _createUserTaskUseCase.ExecuteAsync(title, createdByUserId, cancellationToken);
    }

    public async Task<List<UserTaskModel>> GetAllUserTasksAsync(CancellationToken cancellationToken)
    {
        return await _getUserTasksUseCase.ExecuteAsync(cancellationToken);
    }

    public async Task<UserTaskModel?> GetUserTaskByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _getUserTaskUseCase.ExecuteAsync(id, cancellationToken);
    }

    public async Task<bool> SetUserTaskTitleAsync(Guid id, string title, CancellationToken cancellationToken)
    {
        return await _setUserTaskTitleUseCase.ExecuteAsync(id, title, cancellationToken);
    }

    public async Task<bool> DeleteUserTaskByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _deleteUserTaskUseCase.ExecuteAsync(id, cancellationToken);
    }

    public async Task DeleteAllUserTasksAsync(CancellationToken cancellationToken)
    {
        await _deleteUserTasksUseCase.ExecuteAsync(cancellationToken);
    }
}