using Api.Controllers.UserTasks.Request;
using Api.Controllers.UserTasks.Response;
using Api.Filters;
using Api.UseCases.UserTasks.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Logic.Users.Services.Interfaces;

namespace Api.Controllers.UserTasks;

/// <summary>
/// Контроллер работы с задачами пользователей
/// </summary>
[ApiController]
[Route("user-tasks")]
[ServiceFilter(typeof(StudentInfoHeadersFilter))]
[ServiceFilter(typeof(RequestLoggingFilter))]
public sealed class UserTasksController : ControllerBase
{
    private readonly IManageUserTaskUseCase _userTaskUseCase;
    private readonly IUserService _userService;

    public UserTasksController(IManageUserTaskUseCase userTaskUseCase, IUserService userService)
    {   
        _userTaskUseCase = userTaskUseCase;
        _userService = userService;
    }

    /// <summary>
    /// Создать задачу
    /// </summary>
    [HttpPost]
    [ServiceFilter(typeof(ValidateCreateUserTaskRequestFilter))]
    public async Task<ActionResult<UserTaskResponse>> CreateUserTaskAsync(
        [FromBody] CreateUserTaskRequest request,
        CancellationToken cancellationToken)
    {
        var task = await _userTaskUseCase.CreateUserTaskAsync(request.Title!, request.UserId!.Value, cancellationToken);
        return CreatedAtRoute("GetUserTaskById", new { id = task.Id }, task);
    }

    /// <summary>
    /// Получить все задачи
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<UserTaskListResponse>> GetAllUserTasksAsync(CancellationToken cancellationToken)
    {
        var response = await _userTaskUseCase.GetAllUserTasksAsync(cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Получить задачу по идентификатору
    /// </summary>
    [HttpGet("{id:guid}", Name = "GetUserTaskById")]
    public async Task<ActionResult<UserTaskResponse>> GetUserTaskByIdAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var taskResponse = await _userTaskUseCase.GetUserTaskByIdAsync(id, cancellationToken);
        
        if (taskResponse is null)
        {
            return NotFound();
        }

        return Ok(taskResponse);
    }

    /// <summary>
    /// Изменить название задачи
    /// </summary>
    [HttpPut("{id:guid}/title")]
    [ServiceFilter(typeof(ValidateSetUserTaskTitleRequestFilter))]
    public async Task<IActionResult> SetUserTaskTitleAsync(
        [FromRoute] Guid id,
        [FromBody] SetUserTaskTitleRequest request,
        CancellationToken cancellationToken)
    {
        var updated = await _userTaskUseCase.SetUserTaskTitleAsync(id, request.Title!, cancellationToken);
        
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Удалить задачу по идентификатору
    /// </summary>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUserTaskByIdAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var deleted = await _userTaskUseCase.DeleteUserTaskByIdAsync(id, cancellationToken);
        
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Удалить все задачи
    /// </summary>
    [HttpDelete]
    public async Task<IActionResult> DeleteAllUserTasksAsync(CancellationToken cancellationToken)
    {
        await _userTaskUseCase.DeleteAllUserTasksAsync(cancellationToken);
        return NoContent();
    }
}