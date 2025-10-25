namespace OpenMetrc.V2;

public partial class MetrcService : IEmployeeClient
{
    [MapsToApi(MetrcEndpoint.get_employees_v2)]
    Task<EmployeeMetrcWrapper> IEmployeeClient.GetEmployeesAsync(string licenseNumber, int? pageNumber, int? pageSize,
        CancellationToken cancellationToken) =>
        !CheckEndpointAvailability(MethodBase.GetCurrentMethod())
            ? Task.FromResult(new EmployeeMetrcWrapper())
            : EmployeeClient.GetEmployeesAsync(licenseNumber, pageNumber, pageSize, cancellationToken);

    [MapsToApi(MetrcEndpoint.get_employees_v2_permissions)]
    Task<ICollection<string>> IEmployeeClient.GetEmployeePermissionsAsync(string licenseNumber, string employeeLicenseNumber, CancellationToken cancellationToken) =>
            !CheckEndpointAvailability(MethodBase.GetCurrentMethod())
                ? Task.FromResult<ICollection<string>>(new List<string>()) // Return empty list if unavailable
                : EmployeeClient.GetEmployeePermissionsAsync(licenseNumber, employeeLicenseNumber, cancellationToken); // Delegate to actual client
}