using Dal.Repositories.Interfaces;

namespace Logic.Users.UseCases;

public class SetUserNameUseCase
{
    private readonly IUserRepository _userRepository;

    public SetUserNameUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> ExecuteAsync(Guid id, string name, CancellationToken cancellationToken)
    {
        await _userRepository.SetUserNameAsync(id, name, DateTimeOffset.UtcNow, cancellationToken);
        return true;
    }
}