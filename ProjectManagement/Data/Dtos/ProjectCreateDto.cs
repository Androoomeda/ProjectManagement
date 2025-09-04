namespace ProjectManagement.Data.Dtos
{
	/// <summary>
	/// Represents the data required to create a new project, including project name, client and contractor companies, priority level,
	/// start and end dates, the project manager's employee ID, and a list of employee IDs working on the project.
	/// </summary>
	/// <param name="ProjectName">Name of the project.</param>
	/// <param name="ClientCompany">Client company for the project.</param>
	/// <param name="ContractCompany">Contractor company for the project.</param>
	/// <param name="Priority">Priority level of the project.</param>
	/// <param name="StartDate">Project start date.</param>
	/// <param name="EndDate">Project end date.</param>
	/// <param name="ProjectManagerId">Foreign key of the project manager employee.</param>
	/// <param name="ProjectEmployees">List of project employees data.</param>
	public record class ProjectCreateDto
	(
		string ProjectName,
		string ClientCompany,
		string ContractCompany,
		int Priority,
		DateTime StartDate,
		DateTime EndDate,
		int ProjectManagerId,
		List<int> ProjectEmployeeIds
	);
}
