using Api.Controllers.UserTasks.Response;
using Api.UseCases.UserTasks.Interfaces;
using Logic.UserTasks.Services.Interfaces;

namespace Api.UseCases.UserTasks;

/// <summary>
/// Реализация UseCase управления задачами пользователей
/// </summary>
internal sealed class ManageUserTaskUseCase : IManageUserTaskUseCase
{
    private readonly IUserTaskService _userTaskService;

    public ManageUserTaskUseCase(IUserTaskService userTaskService)
    {
        _userTaskService = userTaskService;
    }

    public async Task<UserTaskResponse> CreateUserTaskAsync(string title, Guid createdByUserId, CancellationToken cancellationToken)
    {
        var task = await _userTaskService.CreateUserTaskAsync(title, createdByUserId, cancellationToken);
        return new UserTaskResponse(task.Id, task.Title, task.CreatedByUserId, task.CreatedUtc);
    }

    public async Task<UserTaskListResponse> GetAllUserTasksAsync(CancellationToken cancellationToken)
    {
        var tasks = await _userTaskService.GetAllUserTasksAsync(cancellationToken);
        var responses = tasks.Select(t => new UserTaskResponse(t.Id, t.Title, t.CreatedByUserId, t.CreatedUtc)).ToList();
        return new UserTaskListResponse(responses);
    }

    public async Task<UserTaskResponse?> GetUserTaskByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var task = await _userTaskService.GetUserTaskByIdAsync(id, cancellationToken);
        if (task == null) return null;
        return new UserTaskResponse(task.Id, task.Title, task.CreatedByUserId, task.CreatedUtc);
    }

    public async Task<bool> SetUserTaskTitleAsync(Guid id, string title, CancellationToken cancellationToken)
    {
        return await _userTaskService.SetUserTaskTitleAsync(id, title, cancellationToken);
    }

    public async Task<bool> DeleteUserTaskByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _userTaskService.DeleteUserTaskByIdAsync(id, cancellationToken);
    }

    public async Task DeleteAllUserTasksAsync(CancellationToken cancellationToken)
    {
        await _userTaskService.DeleteAllUserTasksAsync(cancellationToken);
    }
}