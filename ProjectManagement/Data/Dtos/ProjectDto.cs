namespace ProjectManagement.Data.Dtos
{
	/// <summary>
	/// Represents a project with detailed information including its identifier, name, client and contractor companies, priority level,
	/// start and end dates, project manager details, and a list of employees involved in the project.
	/// </summary>
	/// <param name="ProjectId">Unique key of the project.</param>
	/// <param name="ProjectName">Name of the project.</param>
	/// <param name="ClientCompany">Client company for the project.</param>
	/// <param name="ContractCompany">Contractor company for the project.</param>
	/// <param name="Priority">Priority level of the project.</param>
	/// <param name="StartDate">Project start date.</param>
	/// <param name="EndDate">Project end date.</param>
	/// <param name="ProjectManager">Project manager data.</param>
	/// <param name="ProjectEmployees">List of project employees data.</param>
	public record class ProjectDto
	(
		int ProjectId,
		string ProjectName,
		string ClientCompany,
		string ContractCompany,
		int Priority,
		DateTime StartDate,
		DateTime EndDate,
		EmployeeDto ProjectManager,
		List<EmployeeDto> ProjectEmployees
	);
}
