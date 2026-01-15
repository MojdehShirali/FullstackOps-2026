using FullstackOps.Api.Features.Tasks.Dtos;

namespace FullstackOps.Api.Features.Tasks.Services;

public interface ITaskService
{
    IEnumerable<TaskResponse> GetAll();
    TaskResponse? GetById(Guid id);
    TaskResponse Create(CreateTaskRequest request);
    TaskResponse? Update(Guid id, UpdateTaskRequest request);
    bool Delete(Guid id);

}
