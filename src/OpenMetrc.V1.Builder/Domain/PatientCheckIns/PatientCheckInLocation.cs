using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PatientCheckIns;

public partial record PatientCheckInLocation
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Name")]
    public string? Name { get; init; }

}
