using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Patients;

public partial record Patient
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
