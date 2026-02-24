using Logic.Users.Models;

namespace Logic.Users.Services.Interfaces;

/// <summary>
/// Сервис пользователей
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Создать пользователя
    /// </summary>
    /// <param name="name">Имя пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Модель пользователя</returns>
    Task<UserModel> CreateUserAsync(string name, CancellationToken cancellationToken);

    /// <summary>
    /// Получить всех пользователей
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список пользователей</returns>
    Task<IReadOnlyCollection<UserModel>> GetAllUsersAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получить пользователя по идентификатору
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Модель пользователя или null, если пользователь не найден</returns>
    Task<UserModel?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Установить имя пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="name">Имя пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task SetUserNameAsync(Guid userId, string name, CancellationToken cancellationToken);

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
