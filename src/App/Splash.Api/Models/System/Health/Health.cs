using System.Text.Json.Serialization;

namespace Splash.Api.Models.System.Health;

public record Health()
{
    [JsonPropertyName("releaseId")]
    public int ReleaseId { get; init; }

    [JsonPropertyName("status")]
    public required string Status { get; init; }

    [JsonPropertyName("version")]
    public required string Version { get; init; }

    [JsonPropertyName("checks")]
    public required HealthChecks HealthChecks { get; init; }
}