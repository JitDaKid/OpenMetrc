using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Transporters;

public partial record TransporterVehicle
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("FacilityId")]
    public long? FacilityId { get; init; }

    [JsonPropertyName("Make")]
    public string? Make { get; init; }

    [JsonPropertyName("Model")]
    public string? Model { get; init; }

    [JsonPropertyName("LicensePlateNumber")]
    public string? LicensePlateNumber { get; init; }

    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
