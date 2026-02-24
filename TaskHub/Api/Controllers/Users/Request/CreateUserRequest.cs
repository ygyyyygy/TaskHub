namespace Api.Controllers.Users.Request;

/// <summary>
/// Запрос на создание пользователя
/// </summary>
public record CreateUserRequest
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Name { get; init; }
}