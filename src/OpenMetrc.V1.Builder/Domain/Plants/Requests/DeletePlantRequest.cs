using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants.Requests;

public partial record DeletePlantRequest
{
    [JsonPropertyName("Label")]
    public string? Label { get; init; }

    [JsonPropertyName("WasteMethodName")]
    public string? WasteMethodName { get; init; }

    [JsonPropertyName("WasteMaterialMixed")]
    public string? WasteMaterialMixed { get; init; }

    [JsonPropertyName("WasteWeight")]
    public double? WasteWeight { get; init; }

    [JsonPropertyName("WasteUnitOfMeasureName")]
    public string? WasteUnitOfMeasureName { get; init; }

    [JsonPropertyName("WasteReasonName")]
    public string? WasteReasonName { get; init; }

    [JsonPropertyName("Count")]
    public long? Count { get; init; }

    [JsonPropertyName("ReasonNote")]
    public string? ReasonNote { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateOnly? ActualDate { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

}
