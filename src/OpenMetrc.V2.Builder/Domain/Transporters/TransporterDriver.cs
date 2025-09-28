using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Transporters;

public partial record TransporterDriver
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("FacilityId")]
    public long? FacilityId { get; init; }

    [JsonPropertyName("EmployeeId")]
    public string? EmployeeId { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("DriversLicenseNumber")]
    public string? DriversLicenseNumber { get; init; }

    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
