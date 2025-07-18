using System.Text.Json.Serialization;

namespace Splash.Api.Models.System.Health;

public record HealthCheck()
{
    [JsonPropertyName("description")]
    public required string Description { get; init; }

    [JsonPropertyName("observedUnit")]
    public required string ObservedUnit { get; init; }

    [JsonPropertyName("observedValue")]
    public required int ObservedValue { get; init; }

    [JsonPropertyName("status")]
    public required string Status { get; init; }
}