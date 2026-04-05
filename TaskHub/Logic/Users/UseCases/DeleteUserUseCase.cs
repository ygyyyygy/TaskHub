using Dal.Repositories.Interfaces;

namespace Logic.Users.UseCases;

public class DeleteUserUseCase
{
    private readonly IUserRepository _userRepository;

    public DeleteUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> ExecuteAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _userRepository.DeleteUserByIdAsync(id, cancellationToken);
    }
}