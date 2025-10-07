using System.Text.Json.Serialization;
using OpenMetrc.Builder.Domain.ProcessingJob.Requests;

namespace OpenMetrc.Builder.Domain.Sales;

public partial record SaleDeliveryRetailerById
{
    [JsonPropertyName("Id")]
    public long? Id { get; init; }

    [JsonPropertyName("RetailerDeliveryNumber")]
    public string? RetailerDeliveryNumber { get; init; }

    [JsonPropertyName("FacilityLicenseNumber")]
    public string? FacilityLicenseNumber { get; init; }

    [JsonPropertyName("FacilityName")]
    public string? FacilityName { get; init; }

    [JsonPropertyName("DateTime")]
    public DateTimeOffset? DateTime { get; init; }

    [JsonPropertyName("DriverEmployeeId")]
    public string? DriverEmployeeId { get; init; }

    [JsonPropertyName("DriverName")]
    public string? DriverName { get; init; }

    [JsonPropertyName("DriversLicenseNumber")]
    public string? DriversLicenseNumber { get; init; }

    [JsonPropertyName("VehicleMake")]
    public string? VehicleMake { get; init; }

    [JsonPropertyName("VehicleModel")]
    public string? VehicleModel { get; init; }

    [JsonPropertyName("VehicleLicensePlateNumber")]
    public string? VehicleLicensePlateNumber { get; init; }

    [JsonPropertyName("VehicleInfo")]
    public string? VehicleInfo { get; init; }

    [JsonPropertyName("Direction")]
    public string? Direction { get; init; }

    [JsonPropertyName("EstimatedDepartureDateTime")]
    public DateTimeOffset? EstimatedDepartureDateTime { get; init; }

    [JsonPropertyName("TotalPackages")]
    public long? TotalPackages { get; init; }

    [JsonPropertyName("TotalPrice")]
    public double? TotalPrice { get; init; }

    [JsonPropertyName("TotalPriceSold")]
    public double? TotalPriceSold { get; init; }

    [JsonPropertyName("Destinations")]
    public ICollection<Destinations>? Destinations { get; init; }

    [JsonPropertyName("RetailerDeliveryState")]
    public string? RetailerDeliveryState { get; init; }

    [JsonPropertyName("AllowFullEdit")]
    public bool? AllowFullEdit { get; init; }

    [JsonPropertyName("Leg")]
    public long? Leg { get; init; }

    [JsonPropertyName("RecordedDateTime")]
    public DateOnly? RecordedDateTime { get; init; }

    [JsonPropertyName("LastModified")]
    public DateOnly? LastModified { get; init; }

    [JsonPropertyName("Packages")]
    public ICollection<Packages>? Packages { get; init; }

}
