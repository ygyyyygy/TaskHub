using Dal.Context;
using Dal.Entities;
using Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories;

/// <summary>
/// Реализация репозитория задач пользователей
/// </summary>
public class UserTaskRepository : IUserTaskRepository
{
    private readonly UserTaskDbContext _context;

    public UserTaskRepository(UserTaskDbContext context)
    {
        _context = context;
    }

    public async Task<UserTaskEntity> CreateAsync(UserTaskEntity task, CancellationToken cancellationToken)
    {
        await _context.UserTasks.AddAsync(task, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return task;
    }

    public async Task<List<UserTaskEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.UserTasks
            .OrderByDescending(t => t.CreatedUtc)
            .ToListAsync(cancellationToken);
    }

    public async Task<UserTaskEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.UserTasks
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<bool> UpdateTitleAsync(Guid id, string title, CancellationToken cancellationToken)
    {
        var task = await GetByIdAsync(id, cancellationToken);
        if (task == null)
        {
            return false;
        }

        task.Title = title;
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var task = await GetByIdAsync(id, cancellationToken);
        if (task == null)
        {
            return false;
        }

        _context.UserTasks.Remove(task);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task DeleteAllAsync(CancellationToken cancellationToken)
    {
        await _context.UserTasks.ExecuteDeleteAsync(cancellationToken);
    }
}