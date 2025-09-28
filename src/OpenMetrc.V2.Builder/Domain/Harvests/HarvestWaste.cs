using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Harvests;

public partial record HarvestWaste
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("WasteTypeName")]
    public string? WasteTypeName { get; init; }

    [JsonPropertyName("WasteWeight")]
    public double? WasteWeight { get; init; }

    [JsonPropertyName("UnitOfWeightName")]
    public string? UnitOfWeightName { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateOnly? ActualDate { get; init; }

    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
