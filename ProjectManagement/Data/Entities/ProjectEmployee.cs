namespace ProjectManagement.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class ProjectEmployee
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey(nameof(Project))]
		public int ProjectId { get; set; }
		public Project Project { get; set; }

		[ForeignKey(nameof(Employee))]
		public int EmployeeId { get; set; }
		public Employee Employee { get; set; }
	}
}
