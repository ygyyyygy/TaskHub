using Dal.Entities;
using Dal.Repositories.Interfaces;
using Logic.UserTasks.Models;

namespace Logic.UserTasks.UseCases;

/// <summary>
/// UseCase создания задачи пользователя
/// </summary>
public class CreateUserTaskUseCase
{
    private readonly IUserTaskRepository _userTaskRepository;

    public CreateUserTaskUseCase(IUserTaskRepository userTaskRepository)
    {
        _userTaskRepository = userTaskRepository;
    }

    public async Task<UserTaskModel> ExecuteAsync(string title, Guid createdByUserId, CancellationToken cancellationToken)
    {
        var task = new UserTaskEntity
        {
            Id = Guid.NewGuid(),
            Title = title,
            CreatedByUserId = createdByUserId,
            CreatedUtc = DateTimeOffset.UtcNow
        };

        var created = await _userTaskRepository.CreateAsync(task, cancellationToken);
        
        return new UserTaskModel
        {
            Id = created.Id,
            Title = created.Title,
            CreatedByUserId = created.CreatedByUserId,
            CreatedUtc = created.CreatedUtc
        };
    }
}