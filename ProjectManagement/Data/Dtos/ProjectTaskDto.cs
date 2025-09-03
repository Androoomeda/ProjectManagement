namespace ProjectManagement.Data.Dtos
{
	/// <summary>
	/// Represents a task within a project including its identifier, name, status, priority, comment, assigned employee,
	/// author employee, and the project it belongs to.
	/// </summary>
	/// <param name="TaskId">Unique key of the task.</param>
	/// <param name="TaskName">Name of the task.</param>
	/// <param name="Status">Status of the task.</param>
	/// <param name="Priority">Priority level of the task.</param>
	/// <param name="Comment">Comment or description of the task.</param>
	/// <param name="Assignee">Employee assigned to execute the task.</param>
	/// <param name="Author">Employee who created the task.</param>
	/// <param name="Project">The project to which this task belongs.</param>
	public record class ProjectTaskDto
	(
		 int TaskId,
		string TaskName,
		ProjectTaskStatus Status,
		int Priority,
		string Comment,
		EmployeeDto Assignee,
		EmployeeDto Author,
		ProjectDto Project
	);
}
