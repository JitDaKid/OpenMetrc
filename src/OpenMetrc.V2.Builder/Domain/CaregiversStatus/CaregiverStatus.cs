using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.CaregiversStatus;

public partial record CaregiverStatus
{
    [JsonPropertyName("CaregiverLicenseNumber")]
    public string? CaregiverLicenseNumber { get; init; }

    [JsonPropertyName("Active")]
    public bool? Active { get; init; }

}
