using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches.Requests;

public partial record PlantBatchAdditiveUsingtemplateRequest
{
    [JsonPropertyName("AdditivesTemplateName")]
    public string? AdditivesTemplateName { get; init; }

    [JsonPropertyName("Rate")]
    public string? Rate { get; init; }

    [JsonPropertyName("Volume")]
    public string? Volume { get; init; }

    [JsonPropertyName("TotalAmountApplied")]
    public double? TotalAmountApplied { get; init; }

    [JsonPropertyName("TotalAmountUnitOfMeasure")]
    public string? TotalAmountUnitOfMeasure { get; init; }

    [JsonPropertyName("PlantBatchName")]
    public string? PlantBatchName { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateOnly? ActualDate { get; init; }

}
