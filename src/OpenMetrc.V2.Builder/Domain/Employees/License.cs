using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Employees;

public partial record License
{
    [JsonPropertyName("Number")]
    public string? Number { get; init; }

    [JsonPropertyName("EmployeeLicenseNumber")]
    public string? EmployeeLicenseNumber { get; init; }

    [JsonPropertyName("StartDate")]
    public DateOnly? StartDate { get; init; }

    [JsonPropertyName("EndDate")]
    public DateOnly? EndDate { get; init; }

    [JsonPropertyName("LicenseType")]
    public string? LicenseType { get; init; }

}
