using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Requests;

public class PutAdditivestemplatesRequest
{
    [Required]
    [JsonPropertyName("Id")]
    public long Id { get; set; }

    [Required]
    [JsonPropertyName("Name")]
    public string Name { get; set; } = null!;

    [Required]
    [JsonPropertyName("AdditiveType")]
    public string AdditiveType { get; set; } = null!;

    [Required]
    [JsonPropertyName("ApplicationDevice")]
    public string ApplicationDevice { get; set; } = null!;

    [JsonPropertyName("EpaRegistrationNumber")]
    public string? EpaRegistrationNumber { get; set; }

    [JsonPropertyName("Note")]
    public string? Note { get; set; }

    [JsonPropertyName("ProductSupplier")]
    public string? ProductSupplier { get; set; }

    [JsonPropertyName("ProductTradeName")]
    public string? ProductTradeName { get; set; }

    [JsonPropertyName("RestrictiveEntryIntervalQuantityDescription")]
    public string? RestrictiveEntryIntervalQuantityDescription { get; set; }

    [JsonPropertyName("RestrictiveEntryIntervalTimeDescription")]
    public string? RestrictiveEntryIntervalTimeDescription { get; set; }

    [JsonPropertyName("ActiveIngredients")]
    public List<ActiveIngredient>? ActiveIngredients { get; set; }
}