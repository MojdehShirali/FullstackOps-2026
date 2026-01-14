using System.ComponentModel.DataAnnotations;

namespace FullstackOps.Api.Features.Tasks.Dtos;

public sealed record CreateTaskRequest(
    [Required]
    [MinLength(3)]
    string Title,

    [MaxLength(500)]
    string? Description
);
