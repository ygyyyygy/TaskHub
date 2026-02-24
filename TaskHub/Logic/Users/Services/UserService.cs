using Dal.Repositories.Interfaces;
using Logic.Users.Models;
using Logic.Users.Services.Interfaces;

namespace Logic.Users.Services;

/// <inheritdoc />
internal sealed class UserService : IUserService
{
    /// <summary>
    /// Репозиторий управления пользователями
    /// </summary>
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <inheritdoc />
    public async Task<UserModel> CreateUserAsync(string name, CancellationToken cancellationToken)
    {
        var user = await _userRepository.CreateUserAsync(name, DateTimeOffset.UtcNow, cancellationToken);
        return new UserModel(user.Id, user.Name, user.LastActivityUtc);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<UserModel>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllUsersAsync(cancellationToken);

        var result = users
            .Select(x => new UserModel(x.Id, x.Name, x.LastActivityUtc))
            .ToList()
            .AsReadOnly();

        return result; 
    }

    /// <inheritdoc />
    public async Task<UserModel?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);

        if (user == null)
        {
            return null;
        }
        
        return new UserModel(user.Id, user.Name, user.LastActivityUtc);
    }

    /// <inheritdoc />
    public async Task SetUserNameAsync(Guid userId, string name, CancellationToken cancellationToken)
    {
        await _userRepository.SetUserNameAsync(userId, name, DateTimeOffset.UtcNow, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<bool> DeleteUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _userRepository.DeleteUserByIdAsync(userId, cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteAllUsersAsync(CancellationToken cancellationToken)
    {
        await _userRepository.DeleteAllUsersAsync(cancellationToken); 
    }
}