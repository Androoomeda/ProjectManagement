namespace ProjectManagement.Data.Mapping
{
	using ProjectManagement.Data.Dtos;
	using ProjectManagement.Data.Entities;

	/// <summary>
	/// Extension methods to map <see cref="Employee"/> entities to <see cref="EmployeeDto"/> data.
	/// </summary>
	public static class EmployeesMapping
	{
		/// <summary>
		/// Converts an <see cref="Employee"/> entity to <see cref="EmployeeDto"/> representation.
		/// </summary>
		/// <param name="employee"><see cref="Employee"/> entity to convert.</param>
		/// <returns> <see cref="EmployeeDto"/> object.</returns>
		public static EmployeeDto ToDto(this Employee employee)
		{
			return new EmployeeDto(
				employee.EmployeeId,
				employee.FirstName, 
				employee.LastName,
				employee.MiddleName,
				employee.Email,
				employee.Role
			);
		}
	}
}
