using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Transporters.Requests;

public partial record TransporterDriverRequest
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("DriversLicenseNumber")]
    public string? DriversLicenseNumber { get; init; }

    [JsonPropertyName("EmployeeId")]
    public string? EmployeeId { get; init; }

    [JsonPropertyName("Id")]
    public string? Id { get; init; }

}
