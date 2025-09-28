using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales.Requests;

public partial record SaleDeliveryHubDepartRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

}
