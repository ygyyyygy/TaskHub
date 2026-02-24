namespace Logic.Users.Models;

/// <summary>
/// Модель пользователя для слоя логики
/// </summary>
public sealed class UserModel
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
    /// Конструктор
    /// </summary>
    public UserModel(Guid id, string? name, DateTimeOffset lastActivityUtc)
    {
        Id = id;
        Name = name;
        LastActivityUtc = lastActivityUtc;
    }
}