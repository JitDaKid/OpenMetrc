using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales;

public partial record SaleTransactionByDateRange
{
    [JsonPropertyName("PackageId")]
    public long? PackageId { get; init; }

    [JsonPropertyName("PackageLabel")]
    public string? PackageLabel { get; init; }

    [JsonPropertyName("ProductName")]
    public string? ProductName { get; init; }

    [JsonPropertyName("QuantitySold")]
    public double? QuantitySold { get; init; }

    [JsonPropertyName("UnitOfMeasureName")]
    public string? UnitOfMeasureName { get; init; }

    [JsonPropertyName("UnitOfMeasureAbbreviation")]
    public string? UnitOfMeasureAbbreviation { get; init; }

    [JsonPropertyName("TotalPrice")]
    public double? TotalPrice { get; init; }

    [JsonPropertyName("RecordedDateTime")]
    public DateOnly? RecordedDateTime { get; init; }

    [JsonPropertyName("LastModified")]
    public DateOnly? LastModified { get; init; }

}
