namespace ProjectManagement.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// Represents a task within a project.
	/// </summary>
	public class ProjectTask
	{
		/// <summary>
		/// Unique key of the task.
		/// </summary>
		[Key]
		public int TaskId { get; set; }

		/// <summary>
		/// Name of the task.
		/// </summary>
		[Required, MaxLength(100)]
		public string TaskName { get; set; }

		/// <summary>
		/// Current status of the task (default is ToDo).
		/// </summary>
		public ProjectTaskStatus Status { get; set; } = ProjectTaskStatus.ToDo;

		/// <summary>
		/// Priority level of the task.
		/// </summary>
		public int Priority { get; set; }

		/// <summary>
		/// Comment or description of the task.
		/// </summary>
		public string Comment { get; set; }

		/// <summary>
		/// Foreign key of the employee assigned to the task.
		/// </summary>
		[ForeignKey(nameof(Assignee))]
		public int AssigneeId { get; set; }

		/// <summary>
		/// Employee assigned to execute the task.
		/// </summary>
		public Employee Assignee { get; set; }

		/// <summary>
		/// Foreign key of the employee who authored the task.
		/// </summary>
		[ForeignKey(nameof(Author))]
		public int AuthorId { get; set; }

		/// <summary>
		/// Employee who created the task.
		/// </summary>
		public Employee Author { get; set; }

		/// <summary>
		/// Foreign key of the associated project.
		/// </summary>
		[ForeignKey(nameof(Project))]
		public int ProjectId { get; set; }

		/// <summary>
		/// The project to which this task belongs.
		/// </summary>
		public Project Project { get; set; }
	}
}
