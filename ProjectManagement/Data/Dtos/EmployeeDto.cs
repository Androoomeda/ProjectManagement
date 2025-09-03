namespace ProjectManagement.Data.Dtos
{
	/// <summary>
	/// Represents an employee with unique identifier, first name, last name, middle name, email address, and role.
	/// </summary>
	/// <param name="EmployeeId">Unique key of the employee.</param>
	/// <param name="FirstName">Employee's first name.</param>
	/// <param name="LastName">Employee's last name.</param>
	/// <param name="MiddleName">Employee's middle name.</param>
	/// <param name="Email">Employee's email address.</param>
	/// <param name="Role">Role of the employee (e.g., manager, developer).</param>
	public record class EmployeeDto
	(
		int EmployeeId,
		string FirstName,
		string LastName,
		string MiddleName,
		string Email,
		string Role
	);
}
