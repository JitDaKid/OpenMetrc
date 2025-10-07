using System.Text.Json.Serialization;
using OpenMetrc.Builder.Domain.Packages;

namespace OpenMetrc.Builder.Domain.Tags;

public partial record TagStaged
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("TagInventoryTypeName")]
    public string? TagInventoryTypeName { get; init; }

    [JsonPropertyName("MaxGroupSize")]
    public long? MaxGroupSize { get; init; }

    [JsonPropertyName("FacilityId")]
    public long? FacilityId { get; init; }

    [JsonPropertyName("Label")]
    public string? Label { get; init; }

    [JsonPropertyName("IsUsed")]
    public bool? IsUsed { get; init; }

    [JsonPropertyName("IsArchived")]
    public bool? IsArchived { get; init; }

    [JsonPropertyName("LastModified")]
    public DateOnly? LastModified { get; init; }

    [JsonPropertyName("IsStaged")]
    public bool? IsStaged { get; init; }

    [JsonPropertyName("ProductLabel")]
    public ProductLabel? ProductLabel { get; init; }

    [JsonPropertyName("QrCount")]
    public long? QrCount { get; init; }

}
