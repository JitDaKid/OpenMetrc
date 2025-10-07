using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales.Requests;

public partial record SaleReceiptRequest
{
    [JsonPropertyName("SalesDateTime")]
    public DateTimeOffset? SalesDateTime { get; init; }

    [JsonPropertyName("ExternalReceiptNumber")]
    public string? ExternalReceiptNumber { get; init; }

    [JsonPropertyName("SalesCustomerType")]
    public string? SalesCustomerType { get; init; }

    [JsonPropertyName("Transactions")]
    public ICollection<Transactions>? Transactions { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

}
