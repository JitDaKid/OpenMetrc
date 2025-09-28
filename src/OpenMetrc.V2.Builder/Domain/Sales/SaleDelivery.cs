using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales;

public partial record SaleDelivery
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
