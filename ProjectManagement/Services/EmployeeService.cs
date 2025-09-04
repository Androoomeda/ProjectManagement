namespace ProjectManagement.Services
{
	using Microsoft.EntityFrameworkCore;
	using ProjectManagement.Data;
	using ProjectManagement.Data.Dtos;
	using ProjectManagement.Data.Entities;
	using ProjectManagement.Data.Mapping;

	/// <summary>
	/// Service to manage operations related to <see cref="Employee"/>
	/// </summary>
	public class EmployeeService
	{
		/// <summary>
		/// Database context.
		/// </summary>
		private readonly ProjectManagementContext _context;

		/// <summary>
		/// Initializes a new instance of <see cref="EmployeeService"/>
		/// </summary>
		/// <param name="context">Database context.</param>
		public EmployeeService(ProjectManagementContext context) => _context = context;

		/// <summary>
		/// Gets list of <see cref="EmployeeDto"/>.
		/// </summary>
		/// <param name="search">Optional search string.</param>
		/// <returns>List of <see cref="EmployeeDto"/></returns>
		public async Task<List<EmployeeDto>> GetEmployeesAsync(string? search = null)
		{
			var query = _context.Employees.AsQueryable();

			if (!string.IsNullOrEmpty(search))
			{
				query = query.Where(e =>
					e.FirstName.Contains(search) ||
					e.LastName.Contains(search) ||
					e.MiddleName.Contains(search));
			}

			return await query.Select(e => e.ToDto()).ToListAsync();
		}

		/// <summary>
		/// Gets a <see cref="EmployeeDto"/> by id.
		/// </summary>
		/// <param name="id"><see cref="Employee"/> identifier.</param>
		/// <returns><see cref="EmployeeDto"/> entity.</returns>
		public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id)
		{
			var employee = await _context.Employees.FindAsync(id);

			if (employee != null)
				return employee.ToDto();

			return null;
		}

		/// <summary>
		/// Creates a new <see cref="Employee"/> in the database.
		/// </summary>
		/// <param name="employee"><see cref="Employee"/> entity to create.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public async Task CreateEmployeeAsync(Employee employee)
		{
			_context.Employees.Add(employee);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Updates an existing <see cref="Employee"/> in the database.
		/// </summary>
		/// <param name="id"> <see cref="Employee"/> identifier.</param>
		/// <param name="employeeCreateDto"> <see cref="EmployeeCreateUpdateDto"/> with updated values. </param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public async Task UpdateEmployeeAsync(int id, EmployeeCreateUpdateDto employeeCreateDto)
		{
			var employee = await _context.Projects.FindAsync(id);

			if (employee != null)
			{
				_context.Entry(employee)
					.CurrentValues
					.SetValues(employeeCreateDto.ToEntity());

				await _context.SaveChangesAsync();
			}

			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Deletes a <see cref="Employee"/> from database by id.
		/// </summary>
		/// <param name="id"><see cref="Employee"/> identifier.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public async Task DeleteEmployeeAsync(int id)
		{
			var employee = await _context.Employees.FindAsync(id);
			if(employee != null)
			{
				_context.Employees.Remove(employee);
				await _context.SaveChangesAsync();
			}
		}
	}
}
