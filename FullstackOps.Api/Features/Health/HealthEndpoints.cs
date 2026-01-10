using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FullstackOps.Api.Features.Health;

public static class HealthEndpoints
{
    public static IEndpointRouteBuilder MapHealthFeature(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/__ping", () =>
            Results.Ok(new { status = "ok", utc = DateTimeOffset.UtcNow }));

        endpoints.MapHealthChecks("/health");

        return endpoints;
    }
}
