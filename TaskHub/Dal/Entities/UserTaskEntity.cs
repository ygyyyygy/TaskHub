using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Entities;

/// <summary>
/// Задача пользователя
/// </summary>
[Table("user_tasks")]
public class UserTaskEntity
{
    /// <summary>
    /// Идентификатор задачи
    /// </summary>
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    /// <summary>
    /// Название задачи
    /// </summary>
    [Column("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Идентификатор пользователя, создавшего задачу (внешний ключ)
    /// </summary>
    [Column("created_by_user_id")]
    public Guid CreatedByUserId { get; set; }

    /// <summary>
    /// Дата и время создания задачи в UTC
    /// </summary>
    [Column("created_utc")]
    public DateTimeOffset CreatedUtc { get; set; }
}