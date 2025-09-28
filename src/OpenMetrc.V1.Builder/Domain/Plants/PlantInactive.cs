using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Plants;

public partial record PlantInactive
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("Label")]
    public string? Label { get; init; }

    [JsonPropertyName("State")]
    public string? State { get; init; }

    [JsonPropertyName("GrowthPhase")]
    public string? GrowthPhase { get; init; }

    [JsonPropertyName("GroupTagTypeMax")]
    public long? GroupTagTypeMax { get; init; }

    [JsonPropertyName("TagTypeMax")]
    public long? TagTypeMax { get; init; }

    [JsonPropertyName("PlantBatchId")]
    public long? PlantBatchId { get; init; }

    [JsonPropertyName("PlantBatchName")]
    public string? PlantBatchName { get; init; }

    [JsonPropertyName("PlantBatchTypeId")]
    public long? PlantBatchTypeId { get; init; }

    [JsonPropertyName("PlantBatchTypeName")]
    public string? PlantBatchTypeName { get; init; }

    [JsonPropertyName("StrainId")]
    public long? StrainId { get; init; }

    [JsonPropertyName("StrainName")]
    public string? StrainName { get; init; }

    [JsonPropertyName("LocationId")]
    public long? LocationId { get; init; }

    [JsonPropertyName("LocationName")]
    public string? LocationName { get; init; }

    [JsonPropertyName("HarvestId")]
    public long? HarvestId { get; init; }

    [JsonPropertyName("HarvestedUnitOfWeightName")]
    public string? HarvestedUnitOfWeightName { get; init; }

    [JsonPropertyName("HarvestedUnitOfWeightAbbreviation")]
    public string? HarvestedUnitOfWeightAbbreviation { get; init; }

    [JsonPropertyName("HarvestedWetWeight")]
    public double? HarvestedWetWeight { get; init; }

    [JsonPropertyName("HarvestCount")]
    public long? HarvestCount { get; init; }

    [JsonPropertyName("IsOnHold")]
    public bool? IsOnHold { get; init; }

    [JsonPropertyName("PlantedDate")]
    public DateOnly? PlantedDate { get; init; }

    [JsonPropertyName("VegetativeDate")]
    public DateOnly? VegetativeDate { get; init; }

    [JsonPropertyName("FloweringDate")]
    public DateOnly? FloweringDate { get; init; }

    [JsonPropertyName("HarvestedDate")]
    public DateOnly? HarvestedDate { get; init; }

    [JsonPropertyName("LastModified")]
    public DateOnly? LastModified { get; init; }

}
