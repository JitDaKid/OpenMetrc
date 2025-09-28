using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Harvests;

public partial record HarvestActive
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("HarvestType")]
    public string? HarvestType { get; init; }

    [JsonPropertyName("SourceStrainCount")]
    public long? SourceStrainCount { get; init; }

    [JsonPropertyName("Strains")]
    public ICollection<object>? Strains { get; init; }

    [JsonPropertyName("DryingLocationId")]
    public long? DryingLocationId { get; init; }

    [JsonPropertyName("DryingLocationName")]
    public string? DryingLocationName { get; init; }

    [JsonPropertyName("DryingSublocationId")]
    public long? DryingSublocationId { get; init; }

    [JsonPropertyName("CurrentWeight")]
    public double? CurrentWeight { get; init; }

    [JsonPropertyName("TotalWasteWeight")]
    public double? TotalWasteWeight { get; init; }

    [JsonPropertyName("PlantCount")]
    public long? PlantCount { get; init; }

    [JsonPropertyName("TotalWetWeight")]
    public double? TotalWetWeight { get; init; }

    [JsonPropertyName("TotalRestoredWeight")]
    public double? TotalRestoredWeight { get; init; }

    [JsonPropertyName("PackageCount")]
    public long? PackageCount { get; init; }

    [JsonPropertyName("TotalPackagedWeight")]
    public double? TotalPackagedWeight { get; init; }

    [JsonPropertyName("UnitOfWeightName")]
    public string? UnitOfWeightName { get; init; }

    [JsonPropertyName("IsOnHold")]
    public bool? IsOnHold { get; init; }

    [JsonPropertyName("HarvestStartDate")]
    public DateOnly? HarvestStartDate { get; init; }

    [JsonPropertyName("LastModified")]
    public DateTimeOffset? LastModified { get; init; }

}
