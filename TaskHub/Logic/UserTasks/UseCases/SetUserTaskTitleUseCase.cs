using Dal.Repositories.Interfaces;

namespace Logic.UserTasks.UseCases;

/// <summary>
/// UseCase изменения названия задачи
/// </summary>
public class SetUserTaskTitleUseCase
{
    private readonly IUserTaskRepository _userTaskRepository;

    public SetUserTaskTitleUseCase(IUserTaskRepository userTaskRepository)
    {
        _userTaskRepository = userTaskRepository;
    }

    public async Task<bool> ExecuteAsync(Guid id, string title, CancellationToken cancellationToken)
    {
        return await _userTaskRepository.UpdateTitleAsync(id, title, cancellationToken);
    }
}