namespace OpenMetrc.V2.Builder.Controllers;

/// <inheritdoc />
[ApiController]
[Authorize]
public class EmployeeController : EmployeesControllerBase
{
    /// <inheritdoc cref="EmployeesControllerBase.GetEmployees" />
    [MapsToApi(MetrcEndpoint.get_employees_v2)]
    [ProducesResponseType(typeof(MetrcWrapper<Employee>), StatusCodes.Status200OK)]
    public override Task GetEmployees(
        [Required] string licenseNumber,
        int? pageNumber = null, int? pageSize = null) => Task.CompletedTask;

    /// <inheritdoc cref="EmployeesControllerBase.GetEmployeePermissions" />
    [MapsToApi(MetrcEndpoint.get_employees_v2_permissions)]
    [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
    public override Task GetEmployeePermissions(
        [Required] string licenseNumber,
        [Required] string employeeLicenseNumber) => Task.CompletedTask;
}