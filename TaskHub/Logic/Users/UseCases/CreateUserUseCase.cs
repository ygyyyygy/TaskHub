using Dal.Repositories.Interfaces;
using Logic.Users.Models;

namespace Logic.Users.UseCases;

public class CreateUserUseCase
{
    private readonly IUserRepository _userRepository;

    public CreateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserModel> ExecuteAsync(string name, CancellationToken cancellationToken)
    {
        var created = await _userRepository.CreateUserAsync(
            name, 
            DateTimeOffset.UtcNow, 
            cancellationToken);
        
        return new UserModel(created.Id, created.Name, created.LastActivityUtc);
    }
}