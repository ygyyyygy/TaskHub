using Dal.Repositories.Interfaces;

namespace Logic.Users.UseCases;

public class DeleteUsersUseCase
{
    private readonly IUserRepository _userRepository;

    public DeleteUsersUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await _userRepository.DeleteAllUsersAsync(cancellationToken);
    }
}