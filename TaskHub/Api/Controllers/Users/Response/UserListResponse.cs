namespace Api.Controllers.Users.Response;

/// <summary>
/// Ответ с данными списка пользователя
/// </summary>
public record UserListResponse
{
    /// <summary>
    /// Cписок пользователей
    /// </summary>
    public IReadOnlyCollection<UserResponse> UserList { get; init; }
    
    /// <summary>
    /// Создает ответ с данными пользователя
    /// </summary>
    /// <param name="userList">Список пользователя</param>
    public UserListResponse(IReadOnlyCollection<UserResponse> userList)
    {
        UserList = userList;
    }
}