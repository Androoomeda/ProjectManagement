namespace ProjectManagement.Data.Dtos
{
	/// <summary>
	/// Represents the data for updating a project, including project name, client and contractor companies,
	/// priority, start and end dates, project manager, and the list of project employees.
	/// </summary>
	/// <param name="ProjectName">Name of the project.</param>
	/// <param name="ClientCompany">Client company for the project.</param>
	/// <param name="ContractCompany">Contractor company for the project.</param>
	/// <param name="Priority">Priority level of the project.</param>
	/// <param name="StartDate">Project start date.</param>
	/// <param name="EndDate">Project end date.</param>
	/// <param name="ProjectManager">Project manager data.</param>
	/// <param name="ProjectEmployees">List of project employees data.</param>
	public record class ProjectUpdateDto
	(
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
