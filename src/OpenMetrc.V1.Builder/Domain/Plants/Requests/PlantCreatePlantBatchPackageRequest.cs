using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants.Requests;

public partial record PlantCreatePlantBatchPackageRequest
{
    [JsonPropertyName("PlantLabel")]
    public string? PlantLabel { get; init; }

    [JsonPropertyName("PackageTag")]
    public string? PackageTag { get; init; }

    [JsonPropertyName("PlantBatchType")]
    public string? PlantBatchType { get; init; }

    [JsonPropertyName("Item")]
    public string? Item { get; init; }

    [JsonPropertyName("Location")]
    public string? Location { get; init; }

    [JsonPropertyName("IsTradeSample")]
    public bool? IsTradeSample { get; init; }

    [JsonPropertyName("IsDonation")]
    public bool? IsDonation { get; init; }

    [JsonPropertyName("Count")]
    public long? Count { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateTimeOffset? ActualDate { get; init; }

    [JsonPropertyName("Sublocation")]
    public string? Sublocation { get; init; }

}
