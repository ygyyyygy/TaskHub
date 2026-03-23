using Dal.Repositories.Interfaces;
using Logic.UserTasks.Models;

namespace Logic.UserTasks.UseCases;

/// <summary>
/// UseCase получения задачи по идентификатору
/// </summary>
public class GetUserTaskUseCase
{
    private readonly IUserTaskRepository _userTaskRepository;

    public GetUserTaskUseCase(IUserTaskRepository userTaskRepository)
    {
        _userTaskRepository = userTaskRepository;
    }

    public async Task<UserTaskModel?> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        var task = await _userTaskRepository.GetByIdAsync(id, cancellationToken);
        if (task == null) return null;
        
        return new UserTaskModel
        {
            Id = task.Id,
            Title = task.Title,
            CreatedByUserId = task.CreatedByUserId,
            CreatedUtc = task.CreatedUtc
        };
    }
}