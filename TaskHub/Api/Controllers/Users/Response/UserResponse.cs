namespace Api.Controllers.Users.Response;

/// <summary>
/// Ответ с данными пользователя
/// </summary>
public record UserResponse
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string? Name { get; }

    /// <summary>
    /// Дата и время последней активности пользователя в UTC
    /// </summary>
    public DateTimeOffset LastActivityUtc { get; }

    /// <summary>
    /// Создает ответ с данными пользователя
    /// </summary>
    /// <param name="id">Идентификатор пользователя</param>
    /// <param name="name">Имя пользователя</param>
    /// <param name="lastActivityUtc">Дата и время последней активности пользователя в UTC</param>
    public UserResponse(Guid id, string? name, DateTimeOffset lastActivityUtc)
    {
        Id = id;
        Name = name;
        LastActivityUtc = lastActivityUtc;
    }
}