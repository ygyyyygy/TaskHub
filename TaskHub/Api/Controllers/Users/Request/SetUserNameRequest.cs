namespace Api.Controllers.Users.Request;

/// <summary>
/// Запрос на установку имени пользователя
/// </summary>
public record SetUserNameRequest
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string? Name { get; init; }
}