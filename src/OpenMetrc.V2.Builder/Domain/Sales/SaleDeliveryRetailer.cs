using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales;

public partial record SaleDeliveryRetailer
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
