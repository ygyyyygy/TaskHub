using Api.Controllers.Users.Response;
using Api.UseCases.Users.Interfaces;
using Logic.Users.Services.Interfaces;

namespace Api.UseCases.Users;

/// <summary>
/// UseCase управления пользователями
/// </summary>
internal sealed class ManageUserUseCase : IManageUserUseCase
{
    /// <summary>
    /// Сервис управления пользователем
    /// </summary>
    private readonly IUserService _userService;
    
    public ManageUserUseCase(IUserService userService)
    {
        _userService = userService;
    }
    
    /// <inheritdoc/>
    public async Task<UserResponse> CreateUserAsync(string name, CancellationToken cancellationToken)
    {
        var user = await _userService.CreateUserAsync(name, cancellationToken);
        return new UserResponse(user.Id, user.Name, user.LastActivityUtc);
    }
    
    /// <inheritdoc/>
    public async Task<UserListResponse> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllUsersAsync(cancellationToken);
        
        var response = users
            .Select(x => new UserResponse(x.Id, x.Name, x.LastActivityUtc))
            .ToList()
            .AsReadOnly();

        return new UserListResponse(response);
    }
    
    /// <inheritdoc/>
    public async Task<UserResponse?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserByIdAsync(userId, cancellationToken);
        
        if (user is null)
        {
            return null;
        }
        
        return new UserResponse(user.Id, user.Name, user.LastActivityUtc);
    }
    
    /// <inheritdoc/>
    public async Task DeleteAllUsersAsync(CancellationToken cancellationToken)
    {
        await _userService.DeleteAllUsersAsync(cancellationToken);
    }
    
    /// <inheritdoc/>
    public async Task<bool> DeleteUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _userService.DeleteUserByIdAsync(userId, cancellationToken);
    }
    
    /// <inheritdoc/>
    public async Task SetUserNameAsync(Guid userId, string name, CancellationToken cancellationToken)
    {
        await _userService.SetUserNameAsync(userId, name, cancellationToken);
    }
}