using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants.Requests;

public partial record PlantWasteRequest
{
    [JsonPropertyName("WasteMethodName")]
    public string? WasteMethodName { get; init; }

    [JsonPropertyName("MixedMaterial")]
    public string? MixedMaterial { get; init; }

    [JsonPropertyName("WasteWeight")]
    public double? WasteWeight { get; init; }

    [JsonPropertyName("UnitOfMeasureName")]
    public string? UnitOfMeasureName { get; init; }

    [JsonPropertyName("ReasonName")]
    public string? ReasonName { get; init; }

    [JsonPropertyName("Note")]
    public string? Note { get; init; }

    [JsonPropertyName("LocationName")]
    public string? LocationName { get; init; }

    [JsonPropertyName("SublocationName")]
    public string? SublocationName { get; init; }

    [JsonPropertyName("WasteDate")]
    public DateOnly? WasteDate { get; init; }

    [JsonPropertyName("PlantLabels")]
    public ICollection<string>? PlantLabels { get; init; }

}
