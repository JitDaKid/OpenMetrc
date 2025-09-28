using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales;

public partial record SaleReceipt
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
