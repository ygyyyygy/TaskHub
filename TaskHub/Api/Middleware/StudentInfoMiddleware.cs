namespace Api.Middleware;

/// <summary>
/// Middleware для добавления информации о студенте в заголовки ответа
/// </summary>
public class StudentInfoMiddleware
{
    private readonly RequestDelegate _next;
    private readonly StudentInfo _studentInfo;

    public StudentInfoMiddleware(RequestDelegate next, StudentInfo studentInfo)
    {
        _next = next;
        _studentInfo = studentInfo;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.OnStarting(() =>
        {
            context.Response.Headers.Append("X-Student-Name", _studentInfo.Name);
            context.Response.Headers.Append("X-Student-Group", _studentInfo.Group);
            
            return Task.CompletedTask;
        });
        
        await _next(context);
    }
}

/// <summary>
/// DTO с информацией о студенте
/// </summary>
public record StudentInfo(string Name, string Group);