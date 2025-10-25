namespace OpenMetrc.Builder.Domain;
public class PlantMotherOnHold
{
    [Required]
    [JsonPropertyName("Id")]
    public long Id { get; set; }

    [JsonPropertyName("Label")]
    public string? Label { get; set; }

    [JsonPropertyName("State")]
    public string? State { get; set; }

    [JsonPropertyName("GrowthPhase")]
    public string? GrowthPhase { get; set; }

    [JsonPropertyName("PlantBatchId")]
    public int? PlantBatchId { get; set; }

    [JsonPropertyName("PlantBatchName")]
    public string? PlantBatchName { get; set; }

    [JsonPropertyName("PlantBatchTypeId")]
    public int? PlantBatchTypeId { get; set; }

    [JsonPropertyName("PlantBatchTypeName")]
    public string? PlantBatchTypeName { get; set; }

    [JsonPropertyName("StrainId")]
    public int? StrainId { get; set; }

    [JsonPropertyName("StrainName")]
    public string? StrainName { get; set; }

    [JsonPropertyName("LocationId")]
    public int? LocationId { get; set; }

    [JsonPropertyName("LocationName")]
    public string? LocationName { get; set; }

    [JsonPropertyName("LocationTypeName")]
    public string? LocationTypeName { get; set; }

    [JsonPropertyName("SublocationId")]
    public int? SublocationId { get; set; }

    [JsonPropertyName("SublocationName")]
    public string? SublocationName { get; set; }

    [JsonPropertyName("RoomId")]
    public int? RoomId { get; set; }

    [JsonPropertyName("RoomName")]
    public string? RoomName { get; set; }

    [JsonPropertyName("PatientLicenseNumber")]
    public string? PatientLicenseNumber { get; set; }

    [JsonPropertyName("HarvestId")]
    public int? HarvestId { get; set; }

    [JsonPropertyName("HarvestedUnitOfWeightName")]
    public string? HarvestedUnitOfWeightName { get; set; }

    [JsonPropertyName("HarvestedUnitOfWeightAbbreviation")]
    public string? HarvestedUnitOfWeightAbbreviation { get; set; }

    [JsonPropertyName("HarvestedWetWeight")]
    public double? HarvestedWetWeight { get; set; }

    [JsonPropertyName("HarvestCount")]
    public int? HarvestCount { get; set; }

    [JsonPropertyName("IsOnHold")]
    public bool IsOnHold { get; set; }

    [JsonPropertyName("PlantedDate")]
    public DateOnly? PlantedDate { get; set; }

    [JsonPropertyName("VegetativeDate")]
    public DateOnly? VegetativeDate { get; set; }

    [JsonPropertyName("FloweringDate")]
    public DateOnly? FloweringDate { get; set; }

    [JsonPropertyName("HarvestedDate")]
    public DateOnly? HarvestedDate { get; set; }

    [JsonPropertyName("DestroyedDate")]
    public DateOnly? DestroyedDate { get; set; }

    [JsonPropertyName("DestroyedNote")]
    public string? DestroyedNote { get; set; }

    [JsonPropertyName("DestroyedByUserName")]
    public string? DestroyedByUserName { get; set; }

    [JsonPropertyName("MotherPlantDate")]
    public DateOnly? MotherPlantDate { get; set; }

    [JsonPropertyName("LastModified")]
    public DateTimeOffset LastModified { get; set; }

    [JsonPropertyName("GroupTagTypeMax")]
    public int? GroupTagTypeMax { get; set; }

    [JsonPropertyName("IsOnTrip")]
    public bool? IsOnTrip { get; set; }

    [JsonPropertyName("TagTypeMax")]
    public int? TagTypeMax { get; set; }

    [JsonPropertyName("ClonedCount")]
    public int? ClonedCount { get; set; }

    [JsonPropertyName("SurvivedCount")]
    public int? SurvivedCount { get; set; }

    [JsonPropertyName("DescendedCount")]
    public int? DescendedCount { get; set; }
}