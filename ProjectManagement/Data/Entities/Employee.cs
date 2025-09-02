namespace ProjectManagement.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.Collections.Generic;

	/// <summary>
	/// Employee class with personal data.
	/// </summary>
	public class Employee
	{
		/// <summary>
		/// Unique key of the employee.
		/// </summary>
		[Key]
		public int EmployeeId { get; set; }

		/// <summary>
		/// Employees's first name.
		/// </summary>
		[Required, MaxLength(50)]
		public string FirstName { get; set; }

		/// <summary>
		/// Employess's last name.
		/// </summary>
		[Required, MaxLength(50)]
		public string LastName { get; set; }

		/// <summary>
		/// Employee's middle name.
		/// </summary>
		[MaxLength(50)]
		public string MiddleName { get; set; }

		/// <summary>
		/// Employee's email address.
		/// </summary>
		[Required, EmailAddress]
		public string Email { get; set; }

		/// <summary>
		/// Role of the employee (manager, developer).
		/// </summary>
		public string Role { get; set; }

		/// <summary>
		/// Projects associated with the employee.
		/// </summary>
		public ICollection<ProjectEmployee> ProjectEmployees { get; set; }

		/// <summary>
		/// Tasks authored by the employee.
		/// </summary>
		public ICollection<ProjectTask> AuthoredTasks { get; set; }

		/// <summary>
		/// Tasks assigned to the employee.
		/// </summary>
		public ICollection<ProjectTask> AssignedTasks { get; set; }
	}
}
