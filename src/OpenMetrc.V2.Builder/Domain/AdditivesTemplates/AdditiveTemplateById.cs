using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.AdditivesTemplates;

public partial record AdditiveTemplateById
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("FacilityId")]
    public long? FacilityId { get; init; }

    [JsonPropertyName("AdditiveType")]
    public string? AdditiveType { get; init; }

    [JsonPropertyName("ApplicationDevice")]
    public string? ApplicationDevice { get; init; }

    [JsonPropertyName("EpaRegistrationNumber")]
    public string? EpaRegistrationNumber { get; init; }

    [JsonPropertyName("ProductSupplier")]
    public string? ProductSupplier { get; init; }

    [JsonPropertyName("ProductTradeName")]
    public string? ProductTradeName { get; init; }

    [JsonPropertyName("ActiveIngredients")]
    public ICollection<ActiveIngredients>? ActiveIngredients { get; init; }

    [JsonPropertyName("LastModified")]
    public DateOnly? LastModified { get; init; }

    [JsonPropertyName("IsActive")]
    public bool? IsActive { get; init; }

}
