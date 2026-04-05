using Dal.Repositories.Interfaces;
using Logic.Users.Models;

namespace Logic.Users.UseCases;

public class GetUsersUseCase
{
    private readonly IUserRepository _userRepository;

    public GetUsersUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserModel>> ExecuteAsync(CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllUsersAsync(cancellationToken);
        
        return users.Select(u => new UserModel(u.Id, u.Name, u.LastActivityUtc)).ToList();
    }
}