namespace FullstackOps.Api.Features.Tasks.Dtos;

public sealed record TaskResponse(
    Guid Id,
    string Title,
    string? Description
);
