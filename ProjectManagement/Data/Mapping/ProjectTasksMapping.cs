namespace ProjectManagement.Data.Mapping
{
	using ProjectManagement.Data.Dtos;
	using ProjectManagement.Data.Entities;

	/// <summary>
	/// Extension methods for mapping <see cref="ProjectTask"/> entities to their corresponding DTOs.
	/// </summary>
	public static class ProjectTasksMapping
	{
		/// <summary>
		/// Converts a <see cref="ProjectTask"/> entity to a <see cref="ProjectTaskDto"/> object.
		/// </summary>
		/// <param name="task">The <see cref="ProjectTask"/> entity to convert.</param>
		/// <returns>A <see cref="ProjectTaskDto"/> containing mapped data from the entity.</returns>
		public static ProjectTaskDto ToDto(this ProjectTask task)
		{
			return new ProjectTaskDto(
				task.TaskId,
				task.TaskName,
				task.Status,
				task.Priority,
				task.Comment,
				task.Assignee.ToDto(),
				task.Author.ToDto(),
				task.Project.ToDto()
			);
		}
	}
}
