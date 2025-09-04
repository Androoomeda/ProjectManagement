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
		/// Converts a <see cref="ProjectTask"/> entity to a <see cref="TaskDto"/> object.
		/// </summary>
		/// <param name="task">The <see cref="ProjectTask"/> entity to convert.</param>
		/// <returns>A <see cref="TaskDto"/> containing mapped data from the entity.</returns>
		public static TaskDto ToDto(this ProjectTask task)
		{
			return new TaskDto(
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


		/// <summary>
		/// Converts a <see cref="TaskCreateUpdateDto"/> to a new <see cref="ProjectTask"/> entity.
		/// </summary>
		/// <param name="taskCreateDto">The <see cref="TaskCreateUpdateDto"/> containing data for creating a new <see cref="ProjectTask"/>.</param>
		/// <returns>A new <see cref="ProjectTask"/> entity populated with the DTO's data.</returns>
		public static ProjectTask ToEntity(this TaskCreateUpdateDto taskCreateDto)
		{
			return new ProjectTask
			{
				TaskName = taskCreateDto.TaskName,
				Status = taskCreateDto.Status,
				Priority = taskCreateDto.Priority,
				Comment = taskCreateDto.Comment,
				Assignee = taskCreateDto.Assignee.ToEntity(),
				Author = taskCreateDto.Author.ToEntity()
			};
		}
	}
}
