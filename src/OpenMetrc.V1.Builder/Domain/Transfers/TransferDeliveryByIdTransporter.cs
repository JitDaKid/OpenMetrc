using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Transfers;

public partial record TransferDeliveryByIdTransporter
{
    [JsonPropertyName("TransporterFacilityLicenseNumber")]
    public string? TransporterFacilityLicenseNumber { get; init; }

    [JsonPropertyName("TransporterFacilityName")]
    public string? TransporterFacilityName { get; init; }

    [JsonPropertyName("TransporterDirection")]
    public string? TransporterDirection { get; init; }

}
