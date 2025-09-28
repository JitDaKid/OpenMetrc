using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.LabTests;

public partial record LabTestRecord
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
