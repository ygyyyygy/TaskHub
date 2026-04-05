using Dal.Repositories.Interfaces;

namespace Logic.UserTasks.UseCases;

/// <summary>
/// UseCase удаления всех задач
/// </summary>
public class DeleteUserTasksUseCase
{
    private readonly IUserTaskRepository _userTaskRepository;

    public DeleteUserTasksUseCase(IUserTaskRepository userTaskRepository)
    {
        _userTaskRepository = userTaskRepository;
    }

    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await _userTaskRepository.DeleteAllAsync(cancellationToken);
    }
}