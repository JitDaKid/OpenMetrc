using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.ProcessingJob;

public partial record ProcessingActive
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("Number")]
    public string? Number { get; init; }

    [JsonPropertyName("JobTypeId")]
    public long? JobTypeId { get; init; }

    [JsonPropertyName("StartDate")]
    public DateOnly? StartDate { get; init; }

    [JsonPropertyName("TotalCount")]
    public double? TotalCount { get; init; }

    [JsonPropertyName("CountUnitOfMeasureId")]
    public long? CountUnitOfMeasureId { get; init; }

    [JsonPropertyName("CountUnitOfMeasureName")]
    public string? CountUnitOfMeasureName { get; init; }

    [JsonPropertyName("TotalVolume")]
    public double? TotalVolume { get; init; }

    [JsonPropertyName("VolumeUnitOfMeasureId")]
    public long? VolumeUnitOfMeasureId { get; init; }

    [JsonPropertyName("VolumeUnitOfMeasureName")]
    public string? VolumeUnitOfMeasureName { get; init; }

    [JsonPropertyName("TotalWeight")]
    public double? TotalWeight { get; init; }

    [JsonPropertyName("WeightUnitOfMeasureId")]
    public long? WeightUnitOfMeasureId { get; init; }

    [JsonPropertyName("WeightUnitOfMeasureName")]
    public string? WeightUnitOfMeasureName { get; init; }

    [JsonPropertyName("Packages")]
    public ICollection<object>? Packages { get; init; }

    [JsonPropertyName("IsFinished")]
    public bool? IsFinished { get; init; }

}
