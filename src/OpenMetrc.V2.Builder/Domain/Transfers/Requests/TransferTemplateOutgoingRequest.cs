using System.Text.Json.Serialization;
using OpenMetrc.Builder.Domain.Sales;

namespace OpenMetrc.Builder.Domain.Transfers.Requests;

public partial record TransferTemplateOutgoingRequest
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("Destinations")]
    public ICollection<Destinations>? Destinations { get; init; }

    [JsonPropertyName("TransferTemplateId")]
    public long? TransferTemplateId { get; init; }

}
