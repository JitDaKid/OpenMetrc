using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales;

public partial record SaleDeliveryRetailerRestock
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
