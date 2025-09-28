using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales.Requests;

public partial record SaleDeliveryRetailerEndRequest
{
    [JsonPropertyName("RetailerDeliveryId")]
    public long? RetailerDeliveryId { get; init; }

    [JsonPropertyName("ActualArrivalDateTime")]
    public DateTimeOffset? ActualArrivalDateTime { get; init; }

    [JsonPropertyName("Packages")]
    public ICollection<object>? Packages { get; init; }

}
