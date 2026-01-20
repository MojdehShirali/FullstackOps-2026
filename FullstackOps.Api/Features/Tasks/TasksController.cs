using FullstackOps.Api.Features.Tasks.Dtos;
using FullstackOps.Api.Features.Tasks.Services;
using Microsoft.AspNetCore.Mvc;

namespace FullstackOps.Api.Features.Tasks;

[ApiController]
[Route("api/tasks")]
public sealed class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TaskResponse>> GetAll([FromQuery] TaskQueryParameters parameters)
    {
        return Ok(_taskService.GetAll(parameters));
    }


    [HttpGet("{id:guid}")]
    public ActionResult<TaskResponse> GetById(Guid id)
    {
        var task = _taskService.GetById(id);
        return task is null ? NotFound() : Ok(task);
    }

    [HttpPost]
    public ActionResult<TaskResponse> Create(CreateTaskRequest request)
    {
        var task = _taskService.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }

    [HttpPut("{id:guid}")]
    public ActionResult<TaskResponse> Update(Guid id, UpdateTaskRequest request)
    {
        var task = _taskService.Update(id, request);
        return task is null ? NotFound() : Ok(task);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var deleted = _taskService.Delete(id);
        return deleted ? NoContent() : NotFound();
    }
}
