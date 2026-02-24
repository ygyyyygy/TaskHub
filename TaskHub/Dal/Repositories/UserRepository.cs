using Dal.Context;
using Dal.Entities;
using Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories;

/// <inheritdoc />
public sealed class UserRepository : IUserRepository
{
    /// <summary>
    /// Контекст базы данных пользователей
    /// </summary>
    private readonly UserDbContext _dbContext;

    public UserRepository(UserDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<User> CreateUserAsync(string name, DateTimeOffset lastActivityUtc, CancellationToken cancellationToken)
    {
        var userId = Guid.NewGuid();
        var user = new User
        {
            Id = userId,
            Name = name,
            LastActivityUtc = lastActivityUtc
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return user;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<User>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        var users = await _dbContext.Users
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return users.AsReadOnly();
    }

    /// <inheritdoc />
    public async Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
    }

    /// <inheritdoc />
    public async Task SetUserNameAsync(Guid userId, string name, DateTimeOffset lastActivityUtc, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
        if (user is null)
        {
            user = new User
            {
                Id = userId,
                Name = name,
                LastActivityUtc = lastActivityUtc
            };

            _dbContext.Users.Add(user);
        }
        else
        {
            user.Name = name;
            user.LastActivityUtc = lastActivityUtc;
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<bool> DeleteUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
        if (user is null)
        {
            return false;
        }

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }

    /// <inheritdoc />
    public async Task DeleteAllUsersAsync(CancellationToken cancellationToken)
    {
        var users = await _dbContext.Users.ToListAsync(cancellationToken);
        if (users.Count is 0)
        {
            return;
        }

        _dbContext.Users.RemoveRange(users);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
