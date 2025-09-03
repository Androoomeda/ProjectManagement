namespace ProjectManagement.Services
{
	using Microsoft.EntityFrameworkCore;
	using ProjectManagement.Data;
	using ProjectManagement.Data.Dtos;
	using ProjectManagement.Data.Entities;
	using ProjectManagement.Data.Mapping;

	/// <summary>
	/// Service to manage operations related to <see cref="Project"/>.
	/// </summary>
	public class ProjectService
	{
		/// <summary>
		/// Database context.
		/// </summary>
		private readonly ProjectManagementContext _context;

		/// <summary>
		/// Initializes a new instance of <see cref="ProjectService"/>
		/// </summary>
		/// <param name="context">Database context.</param>
		public ProjectService(ProjectManagementContext context) => _context = context;

		/// <summary>
		/// Gets list of <see cref="Project"/> filtered by optional start date, end date, and priority.
		/// </summary>
		/// <param name="startDate">Filter for <see cref="Project"/> start date.</param>
		/// <param name="endDate">Filter for <see cref="Project"/> end date.</param>
		/// <param name="priority">Filter for <see cref="Project"/> priority.</param>
		/// <returns>List of <see cref="Project"/> matching the filtering.</returns>
		public async Task<List<ProjectDto>> GetProjectsDtosAsync(DateTime? startDate, DateTime? endDate, int? priority)
		{
			var query = _context.Projects.AsQueryable();

			if (startDate.HasValue)
				query = query.Where(p => p.StartDate >= startDate.Value);
			if (endDate.HasValue)
				query = query.Where(p => p.EndDate <= endDate.Value);
			if (priority.HasValue)
				query = query.Where(p => p.Priority == priority.Value);

			var projects = await query
				.Include(p => p.ProjectManager)
				.Include(p => p.ProjectEmployees)
					.ThenInclude(pe => pe.Employee)
				.Select(p => p.ToDto())
				.ToListAsync();

			return projects;
		}

		/// <summary>
		/// Gets a <see cref="Project"/> by id.
		/// </summary>
		/// <param name="id"><see cref="Project"/> identifier.</param>
		/// <returns>The <see cref="Project"/> entity.</returns>
		public async Task<ProjectDto?> GetProjectDtoByIdAsync(int id)
		{
			var project = await _context.Projects.FindAsync(id);

			if (project != null)
				return project.ToDto();

			return null;
		}

		/// <summary>
		/// Creates a new <see cref="Project"/> in the database.
		/// </summary>
		/// <param name="project"><see cref="Project"/> entity to create.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public async Task CreateProjectAsync(Project project)
		{
			_context.Projects.Add(project);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Updates an existing <see cref="Project"/> in the database.
		/// </summary>
		/// <param name="id"> <see cref="Project"/> identifier.</param>
		/// <param name="project"> <see cref="ProjectUpdateDto"/> with updated values. </param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public async Task UpdateProjectAsync(int id, ProjectUpdateDto projectUpdateDto)
		{
			var project = await _context.Projects.FindAsync(id);

			if(project != null)
			{
				_context.Entry(project)
					.CurrentValues
					.SetValues(projectUpdateDto.ToEntity(id));

				await _context.SaveChangesAsync();
			}
		}

		/// <summary>
		/// Deletes a <see cref="Project"/> from database by id.
		/// </summary>
		/// <param name="id"> <see cref="Project"/> identifier. </param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public async Task DeleteProjectAsync(int id)
		{
			var project = await _context.Projects.FindAsync(id);
			if (project != null)
			{
				_context.Projects.Remove(project);
				await _context.SaveChangesAsync();
			}
		}
	}
}
