using FullstackOps.Api.Data;
using FullstackOps.Api.Data.Entities;
using FullstackOps.Api.Features.Tasks.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FullstackOps.Api.Features.Tasks.Services;

public sealed class TaskService : ITaskService
{
    private readonly AppDbContext _db;

    public TaskService(AppDbContext db)
    {
        _db = db;
    }

    public IEnumerable<TaskResponse> GetAll()
        => _db.Tasks
            .AsNoTracking()
            .OrderByDescending(x => x.Id)
            .Select(x => new TaskResponse(x.Id, x.Title, x.Description))
            .ToList();

    public TaskResponse? GetById(Guid id)
        => _db.Tasks
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new TaskResponse(x.Id, x.Title, x.Description))
            .FirstOrDefault();

    public TaskResponse Create(CreateTaskRequest request)
    {
        var entity = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description
        };

        _db.Tasks.Add(entity);
        _db.SaveChanges();

        return new TaskResponse(entity.Id, entity.Title, entity.Description);
    }
}
