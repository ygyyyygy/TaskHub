using Dal.Repositories.Interfaces;

namespace Logic.UserTasks.UseCases;

/// <summary>
/// UseCase удаления задачи по идентификатору
/// </summary>
public class DeleteUserTaskUseCase
{
    private readonly IUserTaskRepository _userTaskRepository;

    public DeleteUserTaskUseCase(IUserTaskRepository userTaskRepository)
    {
        _userTaskRepository = userTaskRepository;
    }

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _userTaskRepository.DeleteByIdAsync(id, cancellationToken);
    }
}