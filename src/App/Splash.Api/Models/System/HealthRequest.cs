using Splash.Api.Models.System.Health;
using System.Text.Json.Serialization;

namespace Splash.Api.Models.System;

public record HealthRequest()
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("deviceId")]
    public required string DeviceId { get; init; }

    [JsonPropertyName("event")]
    public required string Event { get; init; }

    [JsonPropertyName("webhookId")]
    public required string WebhookId { get; init; }

    [JsonPropertyName("payload")]
    public required HealthPayload Payload { get; init; }
}