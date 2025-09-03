namespace ProjectManagement.Data.Mapping
{
	using ProjectManagement.Data.Dtos;
	using ProjectManagement.Data.Entities;

	/// <summary>
	/// Extension methods for mapping between <see cref="Project"/> entities and their corresponding DTOs.
	/// </summary>
	public static class ProjectsMapping
	{
		/// <summary>
		/// Converts a <see cref="Project"/> entity to a <see cref="ProjectDto"/>object.
		/// </summary>
		/// <param name="project"><see cref="Project"/> entity to convert.</param>
		/// <returns><see cref="ProjectDto"/> containing mapped data from the entity.</returns>
		public static ProjectDto ToDto(this Project project)
		{
			return new ProjectDto(
				project.ProjectId,
				project.ProjectName,
				project.ClientCompany,
				project.ContractCompany,
				project.Priority,
				project.StartDate,
				project.EndDate,
				project.ProjectManager.ToDto(),
				project.ProjectEmployees?
					.Where(pe => pe.Employee != null)
					.Select(pe => pe.Employee.ToDto())
					.ToList() ?? new List<EmployeeDto>()
			);
		}

		/// <summary>
		/// Converts a <see cref="ProjectCreateDto"/> to a new <see cref="Project"/> entity.
		/// </summary>
		/// <param name="projectCreateDto">The <see cref="ProjectCreateDto"/> containing data for creating a new <see cref="Project"/>.</param>
		/// <returns>A new <see cref="Project"/> entity populated with the DTO's data.</returns>
		public static Project ToEntity(this ProjectCreateDto projectCreateDto)
		{
			return new Project
			{
				ProjectName = projectCreateDto.ProjectName,
				ClientCompany = projectCreateDto.ClientCompany,
				ContractCompany = projectCreateDto.ContractCompany,
				Priority = projectCreateDto.Priority,
				StartDate = projectCreateDto.StartDate,
				EndDate = projectCreateDto.EndDate,
				ProjectManagerId = projectCreateDto.ProjectManagerId,
				ProjectEmployees = projectCreateDto.ProjectEmployeeIds
					.Select(id => new ProjectEmployee { EmployeeId = id }).ToList()
			};
		}

		/// <summary>
		/// Converts a <see cref="ProjectUpdateDto"/> to a  <see cref="Project"/> entity for updating an existing project.
		/// </summary>
		/// <param name="projectUpdateDto">The <see cref="ProjectUpdateDto"/> containing updated data.</param>
		/// <param name="id">The identifier of the <see cref="Project"/> to update.</param>
		/// <returns>A  <see cref="Project"/> entity with updated properties.</returns>
		public static Project ToEntity(this ProjectUpdateDto projectUpdateDto, int id)
		{
			return new Project()
			{
				ProjectId = id,
				ProjectName = projectUpdateDto.ProjectName,
				ClientCompany = projectUpdateDto.ClientCompany,
				ContractCompany = projectUpdateDto.ContractCompany,
				Priority = projectUpdateDto.Priority,
				StartDate = projectUpdateDto.StartDate,
				EndDate = projectUpdateDto.EndDate,
				ProjectManagerId = projectUpdateDto.ProjectManager.EmployeeId,
				ProjectEmployees = projectUpdateDto.ProjectEmployees
					.Select(p => new ProjectEmployee { EmployeeId = p.EmployeeId }).ToList()
			};
		}
	}
}
