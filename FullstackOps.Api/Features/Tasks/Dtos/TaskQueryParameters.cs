using System.ComponentModel.DataAnnotations;

namespace FullstackOps.Api.Features.Tasks.Dtos;

public sealed record TaskQueryParameters(
    [Range(1, int.MaxValue)]
    int Page = 1,

    [Range(1, 100)]
    int PageSize = 10,

    string? Search = null
);
