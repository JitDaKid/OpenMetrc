using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Transfers;

public partial record TransferDeliveryByIdPackageWholesale
{
    [JsonPropertyName("PackageId")]
    public long? PackageId { get; init; }

    [JsonPropertyName("PackageLabel")]
    public string? PackageLabel { get; init; }

    [JsonPropertyName("ShipperWholesalePrice")]
    public double? ShipperWholesalePrice { get; init; }

    [JsonPropertyName("ReceiverWholesalePrice")]
    public double? ReceiverWholesalePrice { get; init; }

}
