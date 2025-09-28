using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales.Requests;

public partial record SaleDeliveryRetailerDepartRequest
{
    [JsonPropertyName("RetailerDeliveryId")]
    public long? RetailerDeliveryId { get; init; }

}
