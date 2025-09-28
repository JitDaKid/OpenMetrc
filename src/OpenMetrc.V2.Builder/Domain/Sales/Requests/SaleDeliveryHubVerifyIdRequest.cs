using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales.Requests;

public partial record SaleDeliveryHubVerifyIdRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("PaymentType")]
    public string? PaymentType { get; init; }

}
