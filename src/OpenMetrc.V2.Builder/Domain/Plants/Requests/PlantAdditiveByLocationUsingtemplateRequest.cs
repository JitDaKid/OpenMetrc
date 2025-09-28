using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants.Requests;

public partial record PlantAdditiveByLocationUsingtemplateRequest
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

    [JsonPropertyName("LocationName")]
    public string? LocationName { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateOnly? ActualDate { get; init; }

}
