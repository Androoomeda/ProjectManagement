namespace ProjectManagement.Services
{
	using Microsoft.EntityFrameworkCore;
	using ProjectManagement.Data;
	using ProjectManagement.Data.Entities;

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
		/// Gets list of <see cref="Employee"/>.
		/// </summary>
		/// <param name="search"></param>
		/// <returns>List of <see cref="Employee"/></returns>
		public async Task<List<Employee>> GetEmployeesAsync(string? search = null)
		{
			var query = _context.Employees.AsQueryable();

			if (!string.IsNullOrEmpty(search))
			{
				query = query.Where(e =>
					e.FirstName.Contains(search) ||
					e.LastName.Contains(search) ||
					e.MiddleName.Contains(search));
			}

			return await query.ToListAsync();
		}

		/// <summary>
		/// Gets a <see cref="Employee"/> by id.
		/// </summary>
		/// <param name="id"><see cref="Employee"/> identifier.</param>
		/// <returns><see cref="Employee"/> entity.</returns>
		public async Task<Employee?> GetEmployeeByIdAsync(int id)
		{
			return await _context.Employees.FindAsync(id);
		}

		/// <summary>
		/// Adds a new <see cref="Employee"/> to the database.
		/// </summary>
		/// <param name="employee"><see cref="Employee"/> entity to add.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public async Task CreateEmployeeAsync(Employee employee)
		{
			_context.Employees.Add(employee);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Updates an existing <see cref="Employee"/> in the database.
		/// </summary>
		/// <param name="employee"><see cref="Employee"/> entity with updated values. </param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public async Task UpdateEmployeeAsync(Employee employee)
		{
			_context.Employees.Update(employee);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Deletes a <see cref="Employee"/> by id.
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
