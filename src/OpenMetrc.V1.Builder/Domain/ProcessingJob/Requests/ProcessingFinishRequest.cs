using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.ProcessingJob.Requests;

public partial record ProcessingFinishRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("FinishDate")]
    public DateOnly? FinishDate { get; init; }

    [JsonPropertyName("FinishNote")]
    public string? FinishNote { get; init; }

    [JsonPropertyName("TotalWeightWaste")]
    public double? TotalWeightWaste { get; init; }

    [JsonPropertyName("WasteWeightUnitOfMeasureName")]
    public string? WasteWeightUnitOfMeasureName { get; init; }

}
