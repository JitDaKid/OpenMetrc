using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales.Requests;

public partial record Transactions
{
    [JsonPropertyName("PackageLabel")]
    public string? PackageLabel { get; init; }

    [JsonPropertyName("Quantity")]
    public double? Quantity { get; init; }

    [JsonPropertyName("UnitOfMeasure")]
    public string? UnitOfMeasure { get; init; }

    [JsonPropertyName("TotalAmount")]
    public double? TotalAmount { get; init; }

    [JsonPropertyName("UnitThcPercent")]
    public object? UnitThcPercent { get; init; }

    [JsonPropertyName("UnitThcContent")]
    public object? UnitThcContent { get; init; }

    [JsonPropertyName("UnitThcContentUnitOfMeasure")]
    public object? UnitThcContentUnitOfMeasure { get; init; }

    [JsonPropertyName("UnitWeight")]
    public object? UnitWeight { get; init; }

    [JsonPropertyName("UnitWeightUnitOfMeasure")]
    public object? UnitWeightUnitOfMeasure { get; init; }

    [JsonPropertyName("InvoiceNumber")]
    public object? InvoiceNumber { get; init; }

    [JsonPropertyName("Price")]
    public object? Price { get; init; }

    [JsonPropertyName("ExciseTax")]
    public object? ExciseTax { get; init; }

    [JsonPropertyName("CityTax")]
    public object? CityTax { get; init; }

    [JsonPropertyName("CountyTax")]
    public object? CountyTax { get; init; }

    [JsonPropertyName("MunicipalTax")]
    public object? MunicipalTax { get; init; }

    [JsonPropertyName("DiscountAmount")]
    public object? DiscountAmount { get; init; }

    [JsonPropertyName("SubTotal")]
    public object? SubTotal { get; init; }

    [JsonPropertyName("SalesTax")]
    public object? SalesTax { get; init; }

    [JsonPropertyName("QrCodes")]
    public object? QrCodes { get; init; }

}
