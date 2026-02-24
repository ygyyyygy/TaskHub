using Api.Controllers.Users.Response;

namespace Api.UseCases.Users.Interfaces;

/// <summary>
/// UseCase управления пользователями
/// </summary>
public interface IManageUserUseCase
{
    /// <summary>
    /// Выполнить создание пользователя
    /// </summary>
    /// <param name="name">Имя пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Модель пользователя</returns>
    Task<UserResponse> CreateUserAsync(string name, CancellationToken cancellationToken);
    
    /// <summary>
    /// Выполнить получение всех пользователей
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список пользователей</returns>
    Task<UserListResponse> GetAllUsersAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Выполнить получение пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Модель пользователя или null, если пользователь не найден</returns>
    Task<UserResponse?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Выполнить удаление всех пользователей
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    Task DeleteAllUsersAsync(CancellationToken cancellationToken);
    
    /// <summary>
    /// Выполнить удаление пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>true, если пользователь удален, иначе false</returns>
    Task<bool> DeleteUserByIdAsync(Guid userId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Выполнить установку имени пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя</param>
    /// <param name="name">Имя пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task SetUserNameAsync(Guid userId, string name, CancellationToken cancellationToken);
}