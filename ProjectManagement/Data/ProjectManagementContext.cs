namespace ProjectManagement.Data
{
	using Microsoft.EntityFrameworkCore;
	using ProjectManagement.Data.Entities;

	/// <summary>
	/// Represents the <see cref="ProjectManagementContext"/> for project management.
	/// Configures the entity relationships and keys.
	/// </summary>
	public class ProjectManagementContext(DbContextOptions<ProjectManagementContext> options) : DbContext(options)
	{
		/// <summary>
		/// Gets or sets the collection of <see cref="Employee"/> entities in the context.
		/// </summary>
		public DbSet<Employee> Employees => Set<Employee>();

		/// <summary>
		/// Gets or sets the collection of <see cref="Project"/> entities in the context.
		/// </summary>
		public DbSet<Project> Projects => Set<Project>();

		/// <summary>
		/// Gets or sets the collection of <see cref="ProjectTask"/> entities in the context.
		/// </summary>
		public DbSet<ProjectTask> ProjectTasks => Set<ProjectTask>();

		/// <summary>
		/// Gets or sets the collection of <see cref="ProjectEmployee"/> entities in the context.
		/// <see cref="ProjectEmployee"/> represents the association between projects and employees,
		/// linking which employees are assigned to which projects.
		/// </summary>
		public DbSet<ProjectEmployee> ProjectEmployees => Set<ProjectEmployee>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProjectEmployee>()
				.HasKey(pe => pe.Id);

			modelBuilder.Entity<ProjectEmployee>()
				.Property(pe => pe.Id)
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<ProjectEmployee>()
				.HasOne(pe => pe.Project)
				.WithMany(p => p.ProjectEmployees)
				.HasForeignKey(pe => pe.ProjectId);

			modelBuilder.Entity<ProjectEmployee>()
				.HasOne(pe => pe.Employee)
				.WithMany(e => e.ProjectEmployees)
				.HasForeignKey(pe => pe.EmployeeId);

			modelBuilder.Entity<Project>()
				.HasOne(p => p.ProjectManager)
				.WithMany()
				.HasForeignKey(p => p.ProjectManagerId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ProjectTask>()
				.HasOne(t => t.Assignee)
				.WithMany(e => e.AssignedTasks)
				.HasForeignKey(t => t.AssigneeId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ProjectTask>()
				.HasOne(t => t.Author)
				.WithMany(e => e.AuthoredTasks)
				.HasForeignKey(t => t.AuthorId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ProjectTask>()
				.HasOne(t => t.Project)
				.WithMany(p => p.Tasks)
				.HasForeignKey(t => t.ProjectId)
				.OnDelete(DeleteBehavior.Cascade);

			base.OnModelCreating(modelBuilder);
		}
	}
}
