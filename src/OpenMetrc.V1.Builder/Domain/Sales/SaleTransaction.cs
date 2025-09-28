using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales;

public partial record SaleTransaction
{
    [JsonPropertyName("SalesDate")]
    public DateOnly? SalesDate { get; init; }

    [JsonPropertyName("TotalTransactions")]
    public long? TotalTransactions { get; init; }

    [JsonPropertyName("TotalPackages")]
    public long? TotalPackages { get; init; }

    [JsonPropertyName("TotalPrice")]
    public double? TotalPrice { get; init; }

}
