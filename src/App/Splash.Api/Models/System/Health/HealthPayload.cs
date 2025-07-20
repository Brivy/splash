using System.Text.Json.Serialization;

namespace Splash.Api.Models.System.Health;

public record HealthPayload()
{
    [JsonPropertyName("health")]
    public required Health Health { get; init; }
}