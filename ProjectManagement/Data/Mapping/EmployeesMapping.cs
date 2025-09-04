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

		/// <summary>
		/// Converts a <see cref="EmployeeDto"/> to a new <see cref="Employee"/> entity.
		/// </summary>
		/// <param name="employeeDto">The <see cref="EmployeeDto"/> data.</param>
		/// <returns>A new <see cref="Employee"/> entity populated with the DTO's data.</returns>
		public static Employee ToEntity(this EmployeeDto employeeDto)
		{
			return new Employee
			{
				FirstName = employeeDto.FirstName,
				LastName = employeeDto.LastName,
				MiddleName = employeeDto.MiddleName,
				Email = employeeDto.Email,
				Role = employeeDto.Role
			};
		}

		/// <summary>
		/// Converts a <see cref="EmployeeCreateUpdateDto"/> to a new <see cref="Employee"/> entity.
		/// </summary>
		/// <param name="employeeCreateDto">The <see cref="EmployeeCreateUpdateDto"/> containing data for creating a new <see cref="Employee"/>.</param>
		/// <returns>A new <see cref="Employee"/> entity populated with the DTO's data.</returns>
		public static Employee ToEntity(this EmployeeCreateUpdateDto employeeCreateDto)
		{
			return new Employee
			{
				FirstName = employeeCreateDto.FirstName,
				LastName = employeeCreateDto.LastName,
				MiddleName = employeeCreateDto.MiddleName,
				Email = employeeCreateDto.Email,
				Role = employeeCreateDto.Role
			};
		}
	}
}
