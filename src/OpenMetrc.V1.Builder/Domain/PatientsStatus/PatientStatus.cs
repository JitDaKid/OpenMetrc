using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.PatientsStatus;

public partial record PatientStatus
{
    [JsonPropertyName("PatientLicenseNumber")]
    public string? PatientLicenseNumber { get; init; }

    [JsonPropertyName("Active")]
    public bool? Active { get; init; }

    [JsonPropertyName("FlowerOuncesAllowed")]
    public double? FlowerOuncesAllowed { get; init; }

    [JsonPropertyName("ThcOuncesAllowed")]
    public double? ThcOuncesAllowed { get; init; }

    [JsonPropertyName("ConcentrateOuncesAllowed")]
    public double? ConcentrateOuncesAllowed { get; init; }

    [JsonPropertyName("InfusedOuncesAllowed")]
    public double? InfusedOuncesAllowed { get; init; }

    [JsonPropertyName("FlowerOuncesPurchased")]
    public double? FlowerOuncesPurchased { get; init; }

    [JsonPropertyName("ThcOuncesPurchased")]
    public double? ThcOuncesPurchased { get; init; }

    [JsonPropertyName("ConcentrateOuncesPurchased")]
    public double? ConcentrateOuncesPurchased { get; init; }

    [JsonPropertyName("InfusedOuncesPurchased")]
    public double? InfusedOuncesPurchased { get; init; }

    [JsonPropertyName("FlowerOuncesAvailable")]
    public double? FlowerOuncesAvailable { get; init; }

    [JsonPropertyName("ThcOuncesAvailable")]
    public double? ThcOuncesAvailable { get; init; }

    [JsonPropertyName("ConcentrateOuncesAvailable")]
    public double? ConcentrateOuncesAvailable { get; init; }

    [JsonPropertyName("InfusedOuncesAvailable")]
    public double? InfusedOuncesAvailable { get; init; }

    [JsonPropertyName("PurchaseAmountDays")]
    public double? PurchaseAmountDays { get; init; }

}
