namespace ProjectManagement.Services
{
	using Microsoft.EntityFrameworkCore;
	using ProjectManagement.Data;
	using ProjectManagement.Data.Entities;


	/// <summary>
	/// Service to manage operations related to <see cref="ProjectTask"/>
	/// </summary>
	public class ProjectTaskService
	{
		/// <summary>
		/// Database context.
		/// </summary>
		private readonly ProjectManagementContext _context;

		/// <summary>
		/// Initializes a new instance of <see cref="ProjectTaskService"/>
		/// </summary>
		/// <param name="context"></param>
		public ProjectTaskService(ProjectManagementContext context) => _context = context;

		/// <summary>
		/// Gets list of <see cref="ProjectTask"/> filtered by optional projectId, status and priority.
		/// </summary>
		/// <param name="projectId">Filter for <see cref="ProjectTask"/> project identifier.</param>
		/// <param name="status">Filter for <see cref="ProjectTask"/> status.</param>
		/// <param name="priority">Filter for <see cref="ProjectTask"/> priority. </param>
		/// <returns>List of <see cref="ProjectTask"/> matching the filtering. </returns>
		public async Task<List<ProjectTask>> GetTasksAsync(int? projectId = null, 
			ProjectTaskStatus? status = null, int? priority = null)
		{
			var query = _context.ProjectTasks.AsQueryable();

			if(projectId.HasValue)
				query = query.Where(pt => pt.ProjectId == projectId.Value);
			if(status.HasValue)
				query = query.Where(pt => pt.Status == status.Value);
			if(priority.HasValue)
				query = query.Where(pt => pt.Priority == priority.Value);

			return await query.ToListAsync();
		}

		/// <summary>
		/// Gets a <see cref="ProjectTask"/> by id.
		/// </summary>
		/// <param name="id"><see cref="ProjectTask"/> identifier.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public async Task<ProjectTask?> GetTaskByIdAsync(int id) => await _context.ProjectTasks.FindAsync(id);

		/// <summary>
		/// Creates a new <see cref="ProjectTask"/> in the database.
		/// </summary>
		/// <param name="projectTask"><see cref="ProjectTask"/> entity to create.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public async Task CreateTaskAsync(ProjectTask projectTask)
		{
			_context.ProjectTasks.Add(projectTask);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Updates an existing <see cref="ProjectTask"/> in the database.
		/// </summary>
		/// <param name="projectTask"><see cref="ProjectTask"/> entity with updated values.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public async Task UpdateTaskAsync(ProjectTask projectTask)
		{
			_context.ProjectTasks.Update(projectTask);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Deletes a <see cref="ProjectTask"/> from database by id.
		/// </summary>
		/// <param name="id"><see cref="ProjectTask"/> identifier.</param>
		/// <returns>A task representing the asynchronous operation.</returns>
		public async Task DeleteTaskAsync(int id)
		{
			var projectTask = await _context.ProjectTasks.FindAsync(id);

			if (projectTask != null)
			{
				_context.ProjectTasks.Remove(projectTask);
				await _context.SaveChangesAsync();
			}
		}
	}
}
