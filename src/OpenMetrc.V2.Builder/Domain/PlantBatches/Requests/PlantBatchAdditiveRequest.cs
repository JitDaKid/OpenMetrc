using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PlantBatches.Requests;

public partial record PlantBatchAdditiveRequest
{
    [JsonPropertyName("AdditiveType")]
    public string? AdditiveType { get; init; }

    [JsonPropertyName("ProductTradeName")]
    public string? ProductTradeName { get; init; }

    [JsonPropertyName("ProductSupplier")]
    public string? ProductSupplier { get; init; }

    [JsonPropertyName("ApplicationDevice")]
    public string? ApplicationDevice { get; init; }

    [JsonPropertyName("TotalAmountApplied")]
    public double? TotalAmountApplied { get; init; }

    [JsonPropertyName("TotalAmountUnitOfMeasure")]
    public string? TotalAmountUnitOfMeasure { get; init; }

    [JsonPropertyName("ActiveIngredients")]
    public ICollection<object>? ActiveIngredients { get; init; }

    [JsonPropertyName("PlantBatchName")]
    public string? PlantBatchName { get; init; }

    [JsonPropertyName("ActualDate")]
    public DateOnly? ActualDate { get; init; }

}
