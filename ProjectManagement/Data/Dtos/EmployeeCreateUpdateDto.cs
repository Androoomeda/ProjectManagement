namespace ProjectManagement.Data.Dtos
{
	using ProjectManagement.Data.Entities;

	/// <summary>
	/// Represents the data required to create and update <see cref="Employee"/> including name, email, role.
	/// </summary>
	/// <param name="FirstName">Employee's first name.</param>
	/// <param name="LastName">Employee's last name.</param>
	/// <param name="MiddleName">Employee's middle name.</param>
	/// <param name="Email">Employee's email address.</param>
	/// <param name="Role">Role of the employee (e.g., manager, developer).</param>
	public record class EmployeeCreateUpdateDto
	(
		string FirstName,
		string LastName,
		string MiddleName,
		string Email,
		string Role
	);
}
