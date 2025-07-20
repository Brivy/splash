using System.Text.Json.Serialization;

namespace Splash.Api.Models.System.Health;

public record HealthChecks()
{
    [JsonPropertyName("messages:failed")]
    public required HealthCheck MessagesFailed { get; init; }

    [JsonPropertyName("connection:status")]
    public required HealthCheck ConnectionStatus { get; init; }

    [JsonPropertyName("connection:transport")]
    public required HealthCheck ConnectionTransport { get; init; }

    [JsonPropertyName("connection:cellular")]
    public required HealthCheck ConnectionCellular { get; init; }

    [JsonPropertyName("battery:level")]
    public required HealthCheck BatteryLevel { get; init; }

    [JsonPropertyName("battery:charging")]
    public required HealthCheck BatteryCharging { get; init; }
}