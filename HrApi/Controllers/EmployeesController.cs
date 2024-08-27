using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HrApi.Data;
using HrApi.Models;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly HrApiContext _context;

    public EmployeesController(HrApiContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
    {
        var employees = await _context.Employees
            .Include(e => e.Job)
            .Include(e => e.Department)
                .ThenInclude(d => d.Location)
                    .ThenInclude(l => l.Country)
                        .ThenInclude(c => c.Region)
            .ToListAsync();

        return employees;
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployees(
        [FromQuery] int? employeeId = null,
        [FromQuery] string? firstName = null,
        [FromQuery] string? lastName = null,
        [FromQuery] string? email = null,
        [FromQuery] string? departmentName = null,
        [FromQuery] string? countryName = null,
        [FromQuery] string? regionName = null)
    {
        var query = _context.Employees
            .Include(e => e.Job)
            .Include(e => e.Department)
                .ThenInclude(d => d.Location)
                    .ThenInclude(l => l.Country)
                        .ThenInclude(c => c.Region)
            .AsQueryable();

        if (employeeId.HasValue)
            query = query.Where(e => e.EmployeeId == employeeId.Value);
        if (!string.IsNullOrEmpty(firstName))
            query = query.Where(e => e.FirstName.Contains(firstName));
        if (!string.IsNullOrEmpty(lastName))
            query = query.Where(e => e.LastName.Contains(lastName));
        if (!string.IsNullOrEmpty(email))
            query = query.Where(e => e.Email.Contains(email));
        if (!string.IsNullOrEmpty(departmentName))
            query = query.Where(e => e.Department.DepartmentName.Contains(departmentName));
        if (!string.IsNullOrEmpty(countryName))
            query = query.Where(e => e.Department.Location.Country.CountryName.Contains(countryName));
        if (!string.IsNullOrEmpty(regionName))
            query = query.Where(e => e.Department.Location.Country.Region.RegionName.Contains(regionName));

        return await query.ToListAsync();
    }
}
