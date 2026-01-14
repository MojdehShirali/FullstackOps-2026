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
    public ActionResult<IEnumerable<TaskResponse>> GetAll()
        => Ok(_taskService.GetAll());

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
}
