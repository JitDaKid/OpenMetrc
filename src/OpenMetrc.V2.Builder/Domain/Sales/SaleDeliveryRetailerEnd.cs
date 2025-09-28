using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales;

public partial record SaleDeliveryRetailerEnd
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
