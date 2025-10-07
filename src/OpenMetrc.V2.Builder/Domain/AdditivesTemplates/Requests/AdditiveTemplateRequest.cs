using System.Text.Json.Serialization;
using OpenMetrc.Builder.Domain.AdditivesTemplates;

namespace OpenMetrc.Builder.Domain.AdditivesTemplates.Requests;

public partial record AdditiveTemplateRequest
{
    [JsonPropertyName("Name")]
    public string? Name { get; init; }

    [JsonPropertyName("AdditiveType")]
    public string? AdditiveType { get; init; }

    [JsonPropertyName("ApplicationDevice")]
    public string? ApplicationDevice { get; init; }

    [JsonPropertyName("EpaRegistrationNumber")]
    public string? EpaRegistrationNumber { get; init; }

    [JsonPropertyName("Note")]
    public string? Note { get; init; }

    [JsonPropertyName("ProductSupplier")]
    public string? ProductSupplier { get; init; }

    [JsonPropertyName("ProductTradeName")]
    public string? ProductTradeName { get; init; }

    [JsonPropertyName("RestrictiveEntryIntervalQuantityDescription")]
    public string? RestrictiveEntryIntervalQuantityDescription { get; init; }

    [JsonPropertyName("RestrictiveEntryIntervalTimeDescription")]
    public string? RestrictiveEntryIntervalTimeDescription { get; init; }

    [JsonPropertyName("ActiveIngredients")]
    public ICollection<ActiveIngredients>? ActiveIngredients { get; init; }

    [JsonPropertyName("Id")]
    public long? Id { get; init; }

}
