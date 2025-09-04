namespace ProjectManagement.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using ProjectManagement.Data;
	using ProjectManagement.Data.Dtos;
	using ProjectManagement.Data.Entities;
	using ProjectManagement.Data.Mapping;
	using ProjectManagement.Services;

	/// <summary>
	/// Controller for managing <see cref="ProjectTask"/>
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class TasksController : ControllerBase
	{
	    /// <summary>
		/// Service for <see cref="ProjectTask"/> logic and data access.
		/// </summary>
		private readonly ProjectTaskService _taskService;

		/// <summary>
		/// Initializes a new instance of <see cref="TasksController"/>j.
		/// </summary>
		/// <param name="taskService"><see cref="ProjectTaskService"/> instance.</param>
		public TasksController(ProjectTaskService taskService)
		{
			_taskService = taskService;
		}

		/// <summary>
		/// Gets list of <see cref="ProjectTask"/> filtered by optional status and priority.
		/// </summary>
		/// <param name="status">Filter for <see cref="ProjectTask"/> status.</param>
		/// <param name="priority">Filter for <see cref="ProjectTask"/> priority.</param>
		/// <returns>List of <see cref="TaskDto"/> matching the filtering.</returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TaskDto>))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetTasks(int? projectId, ProjectTaskStatus? status, int? priority)
		{
			var taskDtos = await _taskService.GetTasksAsync(projectId, status, priority);

			if(taskDtos.Count == 0) NotFound();

			return Ok(taskDtos);
		}

		/// <summary>
		/// Gets a <see cref="TaskDto"/> by id.
		/// </summary>
		/// <param name="id"><see cref="ProjectTask"/> identifier.</param>
		/// <returns>The <see cref="TaskDto"/> data or 404 if not found.</returns>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetTask(int id)
		{
			var taskDto = await _taskService.GetTaskByIdAsync(id);

			if (taskDto == null) return NotFound();

			return Ok(taskDto);
		}

		/// <summary>
		/// Create a new <see cref="ProjectTask"/>.
		/// </summary>
		/// <param name="projectCreateDto"><see cref="TaskCreateUpdateDto"/> data to create.</param>
		/// <returns>Created new <see cref="TaskDto"/></returns>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TaskDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> CreateTask([FromBody] TaskCreateUpdateDto taskCreateDto)
		{
			var task = taskCreateDto.ToEntity();

			await _taskService.CreateTaskAsync(task);

			return CreatedAtAction(nameof(GetTask), new { id = task.TaskId }, task);
		}

		/// <summary>
		/// Update an existing <see cref="Project"/> by id.
		/// </summary>
		/// <param name="id"><see cref="Project"/> identifier.</param>
		/// <param name="projectUpdateDto">Updated <see cref="TaskCreateUpdateDto"/> data.</param>
		/// <returns>No content on success or bad request.</returns>
		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskCreateUpdateDto taskUpdateDto)
		{
			var task = await _taskService.GetTaskByIdAsync(id);

			if(task == null) return NotFound();

			await _taskService.UpdateTaskAsync(id, taskUpdateDto);

			return NoContent();
		}

		/// <summary>
		/// Delete <see cref="ProjectTask"/> by id.
		/// </summary>
		/// <param name="id"><see cref="ProjectTask"/> identifier.</param>
		/// <returns>No content on success.</returns>
		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteTask(int id)
		{
			var projectTask = await _taskService.GetTaskByIdAsync(id);

			if (projectTask == null) return NotFound();

			await _taskService.DeleteTaskAsync(id);

			return NoContent();
		}
	}
}
