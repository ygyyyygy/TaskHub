using Dal.Entities;

namespace Dal.Repositories.Interfaces;

/// <summary>
/// Репозиторий пользователей
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Создать пользователя
    /// </summary>
    /// <param name="name">Имя пользователя</param>
    /// <param name="lastActivityUtc">Дата и время последней активности в UTC</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Пользователь</returns>
    Task<User> CreateUserAsync(string name, DateTimeOffset lastActivityUtc, CancellationToken cancellationToken);

    /// <summary>
    /// Получить всех пользователей
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список пользователей</returns>
    Task<IReadOnlyCollection<User>> GetAllUsersAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получить пользователя по идентификатору
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Пользователь или null, если пользователь не найден</returns>
    Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Установить имя пользователя и обновить дату последней активности
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="name">Имя пользователя</param>
    /// <param name="lastActivityUtc">Дата и время последней активности в UTC</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task SetUserNameAsync(Guid userId, string name, DateTimeOffset lastActivityUtc, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить пользователя по идентификатору
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>true, если пользователь удален, иначе false</returns>
    Task<bool> DeleteUserByIdAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить всех пользователей
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    Task DeleteAllUsersAsync(CancellationToken cancellationToken);
}