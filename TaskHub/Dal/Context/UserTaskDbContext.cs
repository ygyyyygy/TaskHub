using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.Context;

/// <summary>
/// Контекст базы данных для работы с задачами пользователей
/// </summary>
public class UserTaskDbContext : DbContext
{
    public UserTaskDbContext(DbContextOptions<UserTaskDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Задачи пользователей
    /// </summary>
    public DbSet<UserTaskEntity> UserTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}