using FullstackOps.Api.Features.Tasks.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FullstackOps.Api.Features.Tasks;

[ApiController]
[Route("api/tasks")]
public sealed class TasksController : ControllerBase
{
    private static readonly List<TaskResponse> _tasks = new();

    [HttpGet]
    public ActionResult<IEnumerable<TaskResponse>> GetAll()
    {
        return Ok(_tasks);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<TaskResponse> GetById(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task is null)
            return NotFound();

        return Ok(task);
    }

    [HttpPost]
    public ActionResult<TaskResponse> Create(CreateTaskRequest request)
    {
        var task = new TaskResponse(
            Guid.NewGuid(),
            request.Title,
            request.Description
        );

        _tasks.Add(task);

        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }
}
