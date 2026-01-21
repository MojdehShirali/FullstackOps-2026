using FullstackOps.Api.Features.Tasks.Dtos;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

public sealed class TasksApiTests : IClassFixture<ApiFactory>
{
    private readonly HttpClient _client;

    public TasksApiTests(ApiFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostTasks_ShouldReturn201()
    {
        var request = new CreateTaskRequest("Integration test", "API");

        var response = await _client.PostAsJsonAsync("/api/tasks", request);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}
