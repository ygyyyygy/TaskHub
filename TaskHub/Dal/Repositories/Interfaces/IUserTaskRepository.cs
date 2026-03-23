using Dal.Entities;

namespace Dal.Repositories.Interfaces;

/// <summary>
/// Репозиторий для работы с задачами пользователей
/// </summary>
public interface IUserTaskRepository
{
    Task<UserTaskEntity> CreateAsync(UserTaskEntity task, CancellationToken cancellationToken);
    Task<List<UserTaskEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<UserTaskEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> UpdateTitleAsync(Guid id, string title, CancellationToken cancellationToken);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteAllAsync(CancellationToken cancellationToken);
}