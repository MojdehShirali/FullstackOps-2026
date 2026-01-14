using FullstackOps.Api.Features.Tasks.Dtos;

namespace FullstackOps.Api.Features.Tasks.Services;

public sealed class TaskService : ITaskService
{
    private readonly List<TaskResponse> _tasks = new();

    public IEnumerable<TaskResponse> GetAll()
        => _tasks;

    public TaskResponse? GetById(Guid id)
        => _tasks.FirstOrDefault(t => t.Id == id);

    public TaskResponse Create(CreateTaskRequest request)
    {
        // Ici vivront plus tard les règles métier
        var task = new TaskResponse(
            Guid.NewGuid(),
            request.Title,
            request.Description
        );

        _tasks.Add(task);
        return task;
    }
}
