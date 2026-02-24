namespace Dal.Entities;

/// <summary>
/// Пользователь
/// </summary>
public sealed class User
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Дата и время последней активности пользователя в UTC
    /// </summary>
    public DateTimeOffset LastActivityUtc { get; set; }
}