using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Transporters.Requests;

public partial record TransporterVehicleRequest
{
    [JsonPropertyName("Make")]
    public string? Make { get; init; }

    [JsonPropertyName("Model")]
    public string? Model { get; init; }

    [JsonPropertyName("LicensePlateNumber")]
    public string? LicensePlateNumber { get; init; }

    [JsonPropertyName("Id")]
    public string? Id { get; init; }

}
