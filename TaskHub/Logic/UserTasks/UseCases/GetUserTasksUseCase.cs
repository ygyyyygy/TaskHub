using Dal.Entities;
using Dal.Repositories.Interfaces;
using Logic.UserTasks.Models;

namespace Logic.UserTasks.UseCases;

/// <summary>
/// UseCase получения всех задач пользователя
/// </summary>
public class GetUserTasksUseCase
{
    private readonly IUserTaskRepository _userTaskRepository;

    public GetUserTasksUseCase(IUserTaskRepository userTaskRepository)
    {
        _userTaskRepository = userTaskRepository;
    }

    public async Task<List<UserTaskModel>> ExecuteAsync(CancellationToken cancellationToken)
    {
        var tasks = await _userTaskRepository.GetAllAsync(cancellationToken);
        
        return tasks.Select(t => new UserTaskModel
        {
            Id = t.Id,
            Title = t.Title,
            CreatedByUserId = t.CreatedByUserId,
            CreatedUtc = t.CreatedUtc
        }).ToList();
    }
}