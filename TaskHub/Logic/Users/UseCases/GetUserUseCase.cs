using Dal.Repositories.Interfaces;
using Logic.Users.Models;

namespace Logic.Users.UseCases;

public class GetUserUseCase
{
    private readonly IUserRepository _userRepository;

    public GetUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserModel?> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(id, cancellationToken);
        if (user == null) return null;
        
        return new UserModel(user.Id, user.Name, user.LastActivityUtc);
    }
}