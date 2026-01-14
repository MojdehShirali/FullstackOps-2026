namespace FullstackOps.Api.Features.Tasks.Dtos;

public sealed record CreateTaskRequest(
    string Title,
    string? Description
);
