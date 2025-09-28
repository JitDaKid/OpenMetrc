using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Transfers;

public partial record TransferExternalIncoming
{
    [JsonPropertyName("Ids")]
    public ICollection<long>? Ids { get; init; }

}
