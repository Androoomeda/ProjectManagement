namespace ProjectManagement.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using ProjectManagement.Data.Dtos;
	using ProjectManagement.Data.Entities;
	using ProjectManagement.Data.Mapping;
	using ProjectManagement.Services;

	/// <summary>
	/// Controller for managing <see cref="Employee"/>.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		/// <summary>
		/// Service for <see cref="EmployeeService"/> logic and data access.
		/// </summary>
		private readonly EmployeeService _employeeService;

		/// <summary>
		/// Initializes a new instance of <see cref="ProjectsController"/>.
		/// </summary>
		/// <param name="projectService"><see cref="ProjectService"/> instance.</param>
		public EmployeesController(EmployeeService employeeService) => _employeeService = employeeService;

		/// <summary>
		/// Gets list of <see cref="EmployeeDto"/> with optional search by name.
		/// </summary>
		/// <param name="search">Optional search string.</param>
		/// <returns>List of <see cref="EmployeeDto"/></returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EmployeeDto>))]
		public async Task<IActionResult> GetEmployees(string? search)
		{
			var employees = await _employeeService.GetEmployeesAsync(search);
			return Ok(employees);
		}

		/// <summary>
		/// Get <see cref="EmployeeDto"/> by id.
		/// </summary>
		/// <param name="id"><see cref="Employee"/> identifier.</param>
		/// <returns><see cref="EmployeeDto"/> or 404 if not found.</returns>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmployeeDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetEmployee(int id)
		{
			var employee = await _employeeService.GetEmployeeByIdAsync(id);

			if (employee == null) return NotFound();

			return Ok(employee);
		}

		/// <summary>
		/// Create a new <see cref="Employee"/>.
		/// </summary>
		/// <param name="projectCreateDto"><see cref="EmployeeCreateUpdateDto"/> data to create.</param>
		/// <returns>Created new <see cref="EmployeeDto"/></returns>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EmployeeDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateUpdateDto employeeCreateDto)
		{
			var employee = employeeCreateDto.ToEntity();

			await _employeeService.CreateEmployeeAsync(employee);

			return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId}, employee);
		}

		/// <summary>
		/// Update an existing <see cref="Employee"/> by id.
		/// </summary>
		/// <param name="id"><see cref="Employee"/> identifier.</param>
		/// <param name="employeeUpdateDto">Updated <see cref="EmployeeCreateUpdateDto"/> data.</param>
		/// <returns>No content on success or bad request.</returns>
		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> UpdateEmployee(int id,  [FromBody] EmployeeCreateUpdateDto employeeUpdateDto)
		{
			var employee = await _employeeService.GetEmployeeByIdAsync(id);

			if (employee == null) return NotFound();

			await _employeeService.UpdateEmployeeAsync(id, employeeUpdateDto);

			return NoContent();
		}

		/// <summary>
		/// Delete <see cref="Employee"/> by id.
		/// </summary>
		/// <param name="id"><see cref="Employee"/> identifier.</param>
		/// <returns>No content on success.</returns>
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteEmployee(int id)
		{
			await _employeeService.DeleteEmployeeAsync(id);

			return NoContent();
		}
	}
}
