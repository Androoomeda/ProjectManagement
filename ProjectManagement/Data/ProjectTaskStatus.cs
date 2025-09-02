namespace ProjectManagement.Data
{
	/// <summary>
	/// Defines the status of a project task.
	/// </summary>
	public enum ProjectTaskStatus
	{
		/// <summary>
		/// Task is pending and not started.
		/// </summary>
		ToDo = 0,

		/// <summary>
		/// Task in progress.
		/// </summary>
		InProgress = 1,

		/// <summary>
		/// Task has been completed.
		/// </summary>
		Done = 2
	}
}
