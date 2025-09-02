namespace ProjectManagement.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Collections.Generic;

	/// <summary>
	/// Project class with data about project, manager and employess.
	/// </summary>
	public class Project
	{
		/// <summary>
		/// Unique key of the project.
		/// </summary>
		[Key]
		public int ProjectId { get; set; }

		/// <summary>
		/// Name of the project.
		/// </summary>
		[Required, MaxLength(100)]
		public string ProjectName { get; set; }

		/// <summary>
		/// Client company for the project.
		/// </summary>
		[Required, MaxLength(100)]
		public string ClientCompany { get; set; }

		/// <summary>
		/// Contractor company for the project.
		/// </summary>
		[Required, MaxLength(100)]
		public string ContractCompany { get; set; }

		/// <summary>
		/// Priority level of the project.
		/// </summary>
		public int Priority { get; set; }

		/// <summary>
		/// Project start date.
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// Project end date.
		/// </summary>
		public DateTime EndDate { get; set; }

		/// <summary>
		/// Foreign key of the project manager employee.
		/// </summary>
		[ForeignKey(nameof(ProjectManager))]
		public int ProjectManagerId { get; set; }

		/// <summary>
		/// Navigation property to the project manager employee.
		/// </summary>
		public Employee ProjectManager { get; set; }

		/// <summary>
		/// Collection of employees working on the project.
		/// </summary>
		public ICollection<Employee> ProjectEmployees { get; set; }

		/// <summary>
		/// Collection of tasks associated with the project.
		/// </summary>
		public ICollection<ProjectTask> Tasks { get; set; }
	}
}
