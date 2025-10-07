using System.Text.Json.Serialization;
using OpenMetrc.Builder.Domain.ProcessingJob.Requests;

namespace OpenMetrc.Builder.Domain.Sales.Requests;

public partial record SaleDeliveryRetailerRestockRequest
{
    [JsonPropertyName("RetailerDeliveryId")]
    public long? RetailerDeliveryId { get; init; }

    [JsonPropertyName("DateTime")]
    public DateTimeOffset? DateTime { get; init; }

    [JsonPropertyName("EstimatedDepartureDateTime")]
    public DateTimeOffset? EstimatedDepartureDateTime { get; init; }

    [JsonPropertyName("Packages")]
    public ICollection<Packages>? Packages { get; init; }

}
