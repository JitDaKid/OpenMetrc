using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Sales.Requests;

public partial record SaleDeliveryCompleteRequest
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("ActualArrivalDateTime")]
    public DateTimeOffset? ActualArrivalDateTime { get; init; }

    [JsonPropertyName("AcceptedPackages")]
    public ICollection<string>? AcceptedPackages { get; init; }

    [JsonPropertyName("ReturnedPackages")]
    public ICollection<ReturnedPackages>? ReturnedPackages { get; init; }

}
