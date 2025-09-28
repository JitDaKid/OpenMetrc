using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales.Requests;

public partial record SaleDeliveryRetailerRestockRequest
{
    [JsonPropertyName("RetailerDeliveryId")]
    public long? RetailerDeliveryId { get; init; }

    [JsonPropertyName("DateTime")]
    public DateTimeOffset? DateTime { get; init; }

    [JsonPropertyName("EstimatedDepartureDateTime")]
    public DateTimeOffset? EstimatedDepartureDateTime { get; init; }

    [JsonPropertyName("Packages")]
    public ICollection<object>? Packages { get; init; }

}
