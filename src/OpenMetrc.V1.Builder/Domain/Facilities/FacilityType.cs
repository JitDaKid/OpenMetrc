using System.Text.Json.Serialization;

namespace OpenMetrc.Builder.Domain.Facilities;

public partial record FacilityType
{
    [JsonPropertyName("IsMedical")]
    public bool? IsMedical { get; init; }

    [JsonPropertyName("IsRetail")]
    public bool? IsRetail { get; init; }

    [JsonPropertyName("IsHemp")]
    public bool? IsHemp { get; init; }

    [JsonPropertyName("RestrictHarvestPlantRestoreTimeHours")]
    public object? RestrictHarvestPlantRestoreTimeHours { get; init; }

    [JsonPropertyName("TotalMemberPatientsAllowed")]
    public object? TotalMemberPatientsAllowed { get; init; }

    [JsonPropertyName("RestrictWholesalePriceEditDays")]
    public object? RestrictWholesalePriceEditDays { get; init; }

    [JsonPropertyName("RestrictPlantBatchAdjustmentTimeHours")]
    public object? RestrictPlantBatchAdjustmentTimeHours { get; init; }

    [JsonPropertyName("CanGrowPlants")]
    public bool? CanGrowPlants { get; init; }

    [JsonPropertyName("CanCreateOpeningBalancePlantBatches")]
    public bool? CanCreateOpeningBalancePlantBatches { get; init; }

    [JsonPropertyName("CanClonePlantBatches")]
    public bool? CanClonePlantBatches { get; init; }

    [JsonPropertyName("CanTagPlantBatches")]
    public bool? CanTagPlantBatches { get; init; }

    [JsonPropertyName("CanAssignLocationsToPlantBatches")]
    public bool? CanAssignLocationsToPlantBatches { get; init; }

    [JsonPropertyName("PlantsRequirePatientAffiliation")]
    public bool? PlantsRequirePatientAffiliation { get; init; }

    [JsonPropertyName("PlantBatchesCanContainMotherPlants")]
    public bool? PlantBatchesCanContainMotherPlants { get; init; }

    [JsonPropertyName("CanUpdatePlantStrains")]
    public bool? CanUpdatePlantStrains { get; init; }

    [JsonPropertyName("CanTrackVegetativePlants")]
    public bool? CanTrackVegetativePlants { get; init; }

    [JsonPropertyName("CanCreateImmaturePlantPackagesFromPlants")]
    public bool? CanCreateImmaturePlantPackagesFromPlants { get; init; }

    [JsonPropertyName("CanPackageVegetativePlants")]
    public bool? CanPackageVegetativePlants { get; init; }

    [JsonPropertyName("CanPackageWaste")]
    public bool? CanPackageWaste { get; init; }

    [JsonPropertyName("CanReportHarvestSchedules")]
    public bool? CanReportHarvestSchedules { get; init; }

    [JsonPropertyName("CanSubmitHarvestsForTesting")]
    public bool? CanSubmitHarvestsForTesting { get; init; }

    [JsonPropertyName("CanRequireHarvestSampleLabTestBatches")]
    public bool? CanRequireHarvestSampleLabTestBatches { get; init; }

    [JsonPropertyName("CanReportStrainProperties")]
    public bool? CanReportStrainProperties { get; init; }

    [JsonPropertyName("CanCreateOpeningBalancePackages")]
    public bool? CanCreateOpeningBalancePackages { get; init; }

    [JsonPropertyName("CanCreateDerivedPackages")]
    public bool? CanCreateDerivedPackages { get; init; }

    [JsonPropertyName("CanAssignLocationsToPackages")]
    public bool? CanAssignLocationsToPackages { get; init; }

    [JsonPropertyName("CanUpdateLocationsOnPackages")]
    public bool? CanUpdateLocationsOnPackages { get; init; }

    [JsonPropertyName("PackagesRequirePatientAffiliation")]
    public bool? PackagesRequirePatientAffiliation { get; init; }

    [JsonPropertyName("CanCreateTradeSamplePackages")]
    public bool? CanCreateTradeSamplePackages { get; init; }

    [JsonPropertyName("CanDonatePackages")]
    public bool? CanDonatePackages { get; init; }

    [JsonPropertyName("CanSubmitPackagesForTesting")]
    public bool? CanSubmitPackagesForTesting { get; init; }

    [JsonPropertyName("CanCreateProcessValidationPackages")]
    public bool? CanCreateProcessValidationPackages { get; init; }

    [JsonPropertyName("CanRequirePackageSampleLabTestBatches")]
    public bool? CanRequirePackageSampleLabTestBatches { get; init; }

    [JsonPropertyName("CanReturnPackageQuantity")]
    public bool? CanReturnPackageQuantity { get; init; }

    [JsonPropertyName("CanRequestProductRemediation")]
    public bool? CanRequestProductRemediation { get; init; }

    [JsonPropertyName("CanRemediatePackagesWithFailedLabResults")]
    public bool? CanRemediatePackagesWithFailedLabResults { get; init; }

    [JsonPropertyName("CanRequestProductDecontamination")]
    public bool? CanRequestProductDecontamination { get; init; }

    [JsonPropertyName("CanDecontaminatePackagesWithFailedLabResults")]
    public bool? CanDecontaminatePackagesWithFailedLabResults { get; init; }

    [JsonPropertyName("CanInfuseProducts")]
    public bool? CanInfuseProducts { get; init; }

    [JsonPropertyName("CanRecordProcessingJobs")]
    public bool? CanRecordProcessingJobs { get; init; }

    [JsonPropertyName("CanRecordProductForDestruction")]
    public bool? CanRecordProductForDestruction { get; init; }

    [JsonPropertyName("CanDestroyProduct")]
    public bool? CanDestroyProduct { get; init; }

    [JsonPropertyName("CanTestPackages")]
    public bool? CanTestPackages { get; init; }

    [JsonPropertyName("TestsRequireLabSample")]
    public bool? TestsRequireLabSample { get; init; }

    [JsonPropertyName("CanTransferFromExternalFacilities")]
    public bool? CanTransferFromExternalFacilities { get; init; }

    [JsonPropertyName("CanSellToConsumers")]
    public bool? CanSellToConsumers { get; init; }

    [JsonPropertyName("CanSellToPatients")]
    public bool? CanSellToPatients { get; init; }

    [JsonPropertyName("CanSellToExternalPatients")]
    public bool? CanSellToExternalPatients { get; init; }

    [JsonPropertyName("CanSellToCaregivers")]
    public bool? CanSellToCaregivers { get; init; }

    [JsonPropertyName("AdvancedSales")]
    public bool? AdvancedSales { get; init; }

    [JsonPropertyName("SalesRequirePatientNumber")]
    public bool? SalesRequirePatientNumber { get; init; }

    [JsonPropertyName("SalesRequireExternalPatientNumber")]
    public bool? SalesRequireExternalPatientNumber { get; init; }

    [JsonPropertyName("SalesRequireExternalPatientIdentificationMethod")]
    public bool? SalesRequireExternalPatientIdentificationMethod { get; init; }

    [JsonPropertyName("SalesRequireCaregiverNumber")]
    public bool? SalesRequireCaregiverNumber { get; init; }

    [JsonPropertyName("SalesRequireCaregiverPatientNumber")]
    public bool? SalesRequireCaregiverPatientNumber { get; init; }

    [JsonPropertyName("CanDeliverSalesToConsumers")]
    public bool? CanDeliverSalesToConsumers { get; init; }

    [JsonPropertyName("SalesDeliveryAllowPlannedRoute")]
    public bool? SalesDeliveryAllowPlannedRoute { get; init; }

    [JsonPropertyName("SalesDeliveryAllowAddress")]
    public bool? SalesDeliveryAllowAddress { get; init; }

    [JsonPropertyName("SalesDeliveryAllowCity")]
    public bool? SalesDeliveryAllowCity { get; init; }

    [JsonPropertyName("SalesDeliveryAllowState")]
    public bool? SalesDeliveryAllowState { get; init; }

    [JsonPropertyName("SalesDeliveryAllowCounty")]
    public bool? SalesDeliveryAllowCounty { get; init; }

    [JsonPropertyName("SalesDeliveryAllowZip")]
    public bool? SalesDeliveryAllowZip { get; init; }

    [JsonPropertyName("SalesDeliveryRequireZone")]
    public bool? SalesDeliveryRequireZone { get; init; }

    [JsonPropertyName("EnableExternalIdentifier")]
    public bool? EnableExternalIdentifier { get; init; }

    [JsonPropertyName("SalesDeliveryRequireConsumerId")]
    public bool? SalesDeliveryRequireConsumerId { get; init; }

    [JsonPropertyName("CanDeliverSalesToPatients")]
    public bool? CanDeliverSalesToPatients { get; init; }

    [JsonPropertyName("SalesDeliveryRequirePatientNumber")]
    public bool? SalesDeliveryRequirePatientNumber { get; init; }

    [JsonPropertyName("SalesDeliveryRequireRecipientName")]
    public bool? SalesDeliveryRequireRecipientName { get; init; }

    [JsonPropertyName("IsSalesDeliveryHub")]
    public bool? IsSalesDeliveryHub { get; init; }

    [JsonPropertyName("CanHaveMemberPatients")]
    public bool? CanHaveMemberPatients { get; init; }

    [JsonPropertyName("CanReportPatientCheckIns")]
    public bool? CanReportPatientCheckIns { get; init; }

    [JsonPropertyName("CanSpecifyPatientSalesLimitExemption")]
    public bool? CanSpecifyPatientSalesLimitExemption { get; init; }

    [JsonPropertyName("CanReportPatientsAdverseResponses")]
    public bool? CanReportPatientsAdverseResponses { get; init; }

    [JsonPropertyName("RetailerDelivery")]
    public bool? RetailerDelivery { get; init; }

    [JsonPropertyName("RetailerDeliveryAllowTradeSamples")]
    public bool? RetailerDeliveryAllowTradeSamples { get; init; }

    [JsonPropertyName("RetailerDeliveryAllowDonations")]
    public bool? RetailerDeliveryAllowDonations { get; init; }

    [JsonPropertyName("RetailerDeliveryRequirePrice")]
    public bool? RetailerDeliveryRequirePrice { get; init; }

    [JsonPropertyName("RetailerDeliveryAllowPartialPackages")]
    public bool? RetailerDeliveryAllowPartialPackages { get; init; }

    [JsonPropertyName("CanCreatePartialPackages")]
    public bool? CanCreatePartialPackages { get; init; }

    [JsonPropertyName("CanAdjustSourcePackagesWithPartials")]
    public bool? CanAdjustSourcePackagesWithPartials { get; init; }

    [JsonPropertyName("CanReportOperationalExceptions")]
    public bool? CanReportOperationalExceptions { get; init; }

    [JsonPropertyName("CanReportAdulteration")]
    public bool? CanReportAdulteration { get; init; }

    [JsonPropertyName("CanDownloadProductLabel")]
    public bool? CanDownloadProductLabel { get; init; }

    [JsonPropertyName("CanReceiveAssociateProductLabel")]
    public bool? CanReceiveAssociateProductLabel { get; init; }

    [JsonPropertyName("CanUseComplianceLabel")]
    public bool? CanUseComplianceLabel { get; init; }

    [JsonPropertyName("CanViewSourcePackages")]
    public bool? CanViewSourcePackages { get; init; }

    [JsonPropertyName("EnableSublocations")]
    public bool? EnableSublocations { get; init; }

    [JsonPropertyName("TaxExemptReportingFeesFacilityType")]
    public bool? TaxExemptReportingFeesFacilityType { get; init; }

    [JsonPropertyName("TaxExemptTagOrdersFacilityType")]
    public bool? TaxExemptTagOrdersFacilityType { get; init; }

    [JsonPropertyName("CanAccessCatalog")]
    public bool? CanAccessCatalog { get; init; }

    [JsonPropertyName("CanTrackMotherPlantsAsGrowthPhase")]
    public bool? CanTrackMotherPlantsAsGrowthPhase { get; init; }

}
