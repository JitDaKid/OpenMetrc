using System.Text.Json.Serialization;
using OpenMetrc.Builder.Domain.Employees;

namespace OpenMetrc.Builder.Domain.Facilities;

public partial record Facility
{
    [JsonPropertyName("FacilityId")]
    public long? FacilityId { get; init; }

    [JsonPropertyName("HireDate")]
    public DateOnly? HireDate { get; init; }

    [JsonPropertyName("IsOwner")]
    public bool? IsOwner { get; init; }

    [JsonPropertyName("IsManager")]
    public bool? IsManager { get; init; }

    [JsonPropertyName("IsFinancialContact")]
    public bool? IsFinancialContact { get; init; }

    [JsonPropertyName("Occupations")]
    public ICollection<object>? Occupations { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("Alias")]
    public string? Alias { get; init; }

    [JsonPropertyName("DisplayName")]
    public string? DisplayName { get; init; }

    [JsonPropertyName("CredentialedDate")]
    public DateOnly? CredentialedDate { get; init; }

    [JsonPropertyName("FacilityType")]
    public FacilityType? FacilityType { get; init; }

    [JsonPropertyName("License")]
    public License? License { get; init; }

}
