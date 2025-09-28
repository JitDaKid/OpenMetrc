using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Transfers.Requests;

public partial record TransferTemplateOutgoingRequest
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("Destinations")]
    public ICollection<object>? Destinations { get; init; }

    [JsonPropertyName("TransferTemplateId")]
    public long? TransferTemplateId { get; init; }

}
