using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain;

public class PackageTransferred
{
    [Required]
    [JsonPropertyName("Id")]
    public long Id { get; set; }

    [Required]
    [JsonPropertyName("PackageId")]
    public long PackageId { get; set; }

    [JsonPropertyName("RecipientFacilityLicenseNumber")]
    public string? RecipientFacilityLicenseNumber { get; set; }

    [JsonPropertyName("RecipientFacilityName")]
    public string? RecipientFacilityName { get; set; }

    [JsonPropertyName("ManifestNumber")]
    public string? ManifestNumber { get; set; }

    [JsonPropertyName("PackageLabel")]
    public string? PackageLabel { get; set; }

    [JsonPropertyName("ExternalId")]
    public string? ExternalId { get; set; }

    [JsonPropertyName("SourceHarvestNames")]
    public string? SourceHarvestNames { get; set; }

    [JsonPropertyName("SourcePackageLabels")]
    public string? SourcePackageLabels { get; set; }

    [JsonPropertyName("ProductName")]
    public string? ProductName { get; set; }

    [JsonPropertyName("ProductCategoryName")]
    public string? ProductCategoryName { get; set; }

    [JsonPropertyName("ItemStrainName")]
    public string? ItemStrainName { get; set; }

    [JsonPropertyName("LabTestingStateName")]
    public string? LabTestingStateName { get; set; }

    [JsonPropertyName("ShippedQuantity")]
    public double? ShippedQuantity { get; set; }

    [JsonPropertyName("ShippedUnitOfMeasureAbbreviation")]
    public string? ShippedUnitOfMeasureAbbreviation { get; set; }

    [JsonPropertyName("GrossWeight")]
    public double? GrossWeight { get; set; }

    [JsonPropertyName("GrossUnitOfWeightAbbreviation")]
    public string? GrossUnitOfWeightAbbreviation { get; set; }

    [JsonPropertyName("ShipperWholesalePrice")]
    public double? ShipperWholesalePrice { get; set; }

    [JsonPropertyName("ReceivedQuantity")]
    public double? ReceivedQuantity { get; set; }

    [JsonPropertyName("ReceivedUnitOfMeasureAbbreviation")]
    public string? ReceivedUnitOfMeasureAbbreviation { get; set; }

    [JsonPropertyName("ReceiverWholesalePrice")]
    public double? ReceiverWholesalePrice { get; set; }

    [JsonPropertyName("ShipmentPackageStateName")]
    public string? ShipmentPackageStateName { get; set; }

    [JsonPropertyName("ActualDepartureDateTime")]
    public DateTimeOffset? ActualDepartureDateTime { get; set; }

    [JsonPropertyName("ReceivedDateTime")]
    public DateTimeOffset? ReceivedDateTime { get; set; }

    [JsonPropertyName("ProcessingJobTypeName")]
    public string? ProcessingJobTypeName { get; set; }
}