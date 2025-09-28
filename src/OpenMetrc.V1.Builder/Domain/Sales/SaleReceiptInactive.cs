using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales;

public partial record SaleReceiptInactive
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("ExternalReceiptNumber")]
    public string? ExternalReceiptNumber { get; init; }

    [JsonPropertyName("SalesDateTime")]
    public DateTimeOffset? SalesDateTime { get; init; }

    [JsonPropertyName("SalesCustomerType")]
    public string? SalesCustomerType { get; init; }

    [JsonPropertyName("TotalPackages")]
    public long? TotalPackages { get; init; }

    [JsonPropertyName("TotalPrice")]
    public double? TotalPrice { get; init; }

    [JsonPropertyName("Transactions")]
    public ICollection<object>? Transactions { get; init; }

    [JsonPropertyName("IsFinal")]
    public bool? IsFinal { get; init; }

    [JsonPropertyName("RecordedDateTime")]
    public DateOnly? RecordedDateTime { get; init; }

    [JsonPropertyName("LastModified")]
    public DateOnly? LastModified { get; init; }

}
