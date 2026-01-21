using FullstackOps.Api.Data;
using FullstackOps.Api.Features.Tasks.Dtos;
using FullstackOps.Api.Features.Tasks.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

public sealed class TaskServiceTests
{
    private static AppDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }

    [Fact]
    public void Create_ShouldPersistTask()
    {
        using var db = CreateDbContext();
        var service = new TaskService(db);

        var request = new CreateTaskRequest("Test", "Desc");

        var result = service.Create(request);

        Assert.NotNull(result);
        Assert.Equal("Test", result.Title);
        Assert.Single(db.Tasks);
    }
}
