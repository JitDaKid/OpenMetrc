using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales.Requests;

public partial record ReturnedPackages
{
    [JsonPropertyName("Label")]
    public string? Label { get; init; }

    [JsonPropertyName("ReturnQuantityVerified")]
    public double? ReturnQuantityVerified { get; init; }

    [JsonPropertyName("ReturnUnitOfMeasure")]
    public string? ReturnUnitOfMeasure { get; init; }

    [JsonPropertyName("ReturnReason")]
    public string? ReturnReason { get; init; }

    [JsonPropertyName("ReturnReasonNote")]
    public string? ReturnReasonNote { get; init; }

}
