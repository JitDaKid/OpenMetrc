using System.Text.Json.Serialization;
using OpenMetrc.Builder.Domain.Sales;

namespace OpenMetrc.Builder.Domain.Transfers.Requests;

public partial record TransferExternalIncomingRequest
{
    [JsonPropertyName("ShipperLicenseNumber")]
    public string? ShipperLicenseNumber { get; init; }

    [JsonPropertyName("ShipperName")]
    public string? ShipperName { get; init; }

    [JsonPropertyName("ShipperMainPhoneNumber")]
    public string? ShipperMainPhoneNumber { get; init; }

    [JsonPropertyName("ShipperAddress1")]
    public string? ShipperAddress1 { get; init; }

    [JsonPropertyName("ShipperAddressCity")]
    public string? ShipperAddressCity { get; init; }

    [JsonPropertyName("ShipperAddressState")]
    public string? ShipperAddressState { get; init; }

    [JsonPropertyName("Destinations")]
    public ICollection<Destinations>? Destinations { get; init; }

    [JsonPropertyName("TransferId")]
    public long? TransferId { get; init; }

}
