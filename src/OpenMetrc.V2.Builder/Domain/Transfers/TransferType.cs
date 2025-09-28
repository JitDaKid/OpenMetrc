using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Transfers;

public partial record TransferType
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("TransactionType")]
    public string? TransactionType { get; init; }

    [JsonPropertyName("ForLicensedShipments")]
    public bool? ForLicensedShipments { get; init; }

    [JsonPropertyName("ForExternalIncomingShipments")]
    public bool? ForExternalIncomingShipments { get; init; }

    [JsonPropertyName("ForExternalOutgoingShipments")]
    public bool? ForExternalOutgoingShipments { get; init; }

    [JsonPropertyName("RequiresDestinationGrossWeight")]
    public bool? RequiresDestinationGrossWeight { get; init; }

    [JsonPropertyName("RequiresPackagesGrossWeight")]
    public bool? RequiresPackagesGrossWeight { get; init; }

    [JsonPropertyName("RequiresInvoiceNumber")]
    public bool? RequiresInvoiceNumber { get; init; }

    [JsonPropertyName("RequiresPDFDocument")]
    public bool? RequiresPDFDocument { get; init; }

    [JsonPropertyName("ExternalIncomingCanRecordExternalIdentifier")]
    public bool? ExternalIncomingCanRecordExternalIdentifier { get; init; }

    [JsonPropertyName("ExternalIncomingExternalIdentifierRequired")]
    public bool? ExternalIncomingExternalIdentifierRequired { get; init; }

    [JsonPropertyName("ExternalOutgoingCanRecordExternalIdentifier")]
    public bool? ExternalOutgoingCanRecordExternalIdentifier { get; init; }

    [JsonPropertyName("ExternalOutgoingExternalIdentifierRequired")]
    public bool? ExternalOutgoingExternalIdentifierRequired { get; init; }

}
