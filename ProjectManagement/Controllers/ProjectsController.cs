namespace ProjectManagement.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using ProjectManagement.Services;
	using ProjectManagement.Data.Entities;
	using ProjectManagement.Data.Dtos;
	using ProjectManagement.Data.Mapping;

	/// <summary>
	/// Controller for managing <see cref="Project"/>.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectsController : ControllerBase
	{
		/// <summary>
		/// Service for <see cref="Project"/> logic and data access.
		/// </summary>
		private readonly ProjectService _projectService;

		/// <summary>
		/// Initializes a new instance of <see cref="ProjectsController"/>.
		/// </summary>
		/// <param name="projectService"><see cref="ProjectService"/> instance.</param>
		public ProjectsController(ProjectService projectService) => _projectService = projectService;

		/// <summary>
		/// Gets list of <see cref="Project"/> filtered by optional start date, end date, and priority.
		/// </summary>
		/// <param name="startDate">Filter for <see cref="Project"/> start date.</param>
		/// <param name="endDate">Filter for <see cref="Project"/> end date.</param>
		/// <param name="priority">Filter for <see cref="Project"/> priority.</param>
		/// <returns>List of <see cref="ProjectDto"/> matching the filtering.</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProjectDto>))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetProjects(DateTime? startDate, DateTime? endDate, int? priority)
		{
			var projectDtos = await _projectService.GetProjectsDtosAsync(startDate, endDate, priority);

			if (projectDtos.Count == 0) return NotFound();

			return Ok(projectDtos);
		}

		/// <summary>
		/// Gets a <see cref="ProjectDto"/> by id.
		/// </summary>
		/// <param name="id"><see cref="Project"/> identifier.</param>
		/// <returns>The <see cref="ProjectDto"/> data or 404 if not found.</returns>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetProject(int id)
		{
			var projectDto = await _projectService.GetProjectDtoByIdAsync(id);

			if (projectDto == null) return NotFound();

			return Ok(projectDto);
		}

		/// <summary>
		/// Create a new <see cref="Project"/>.
		/// </summary>
		/// <param name="projectCreateDto"><see cref="ProjectCreateDto"/> data to create.</param>
		/// <returns>Created new <see cref="ProjectDto"/></returns>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProjectDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreateProject([FromBody] ProjectCreateDto projectCreateDto)
		{
			var project = projectCreateDto.ToEntity();

			await _projectService.CreateProjectAsync(project);

			return CreatedAtAction(nameof(GetProject), new {id = project.ProjectId}, project);
		}

		/// <summary>
		/// Update an existing <see cref="Project"/> by id.
		/// </summary>
		/// <param name="id"><see cref="Project"/> identifier.</param>
		/// <param name="projectUpdateDto">Updated <see cref="ProjectUpdateDto"/> data.</param>
		/// <returns>No content on success or bad request.</returns>
		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> UpdateProject(int id, [FromBody] ProjectUpdateDto projectUpdateDto)
		{
			var project = await _projectService.GetProjectDtoByIdAsync(id);

			if (project == null) return NotFound();

			await _projectService.UpdateProjectAsync(id, projectUpdateDto);

			return NoContent();
		}

		/// <summary>
		/// Delete <see cref="Project"/> by id.
		/// </summary>
		/// <param name="id"><see cref="Project"/> identifier.</param>
		/// <returns>No content on success.</returns>
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteProject(int id)
		{
			var project = await _projectService.GetProjectDtoByIdAsync(id);

			if (project == null) return NotFound();

			await _projectService.DeleteProjectAsync(id);

			return NoContent();
		}
	}
}
