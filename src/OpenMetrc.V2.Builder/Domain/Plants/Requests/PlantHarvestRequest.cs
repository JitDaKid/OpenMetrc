using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants.Requests;

public partial record PlantHarvestRequest
{
    [JsonPropertyName("Plant")]
    public string? Plant { get; init; }

    [JsonPropertyName("Weight")]
    public double? Weight { get; init; }

    [JsonPropertyName("UnitOfWeight")]
    public string? UnitOfWeight { get; init; }

    [JsonPropertyName("DryingLocation")]
    public string? DryingLocation { get; init; }

    [JsonPropertyName("DryingSublocation")]
    public string? DryingSublocation { get; init; }

    [JsonPropertyName("HarvestName")]
    public string? HarvestName { get; init; }

    [JsonPropertyName("PatientLicenseNumber")]
    public string? PatientLicenseNumber { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateOnly? ActualDate { get; init; }

}
