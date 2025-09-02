namespace ProjectManagement.Data
{
	using Microsoft.EntityFrameworkCore;
	using ProjectManagement.Data.Entities;

	public class ProjectManagementContext(DbContextOptions<ProjectManagementContext> options) : DbContext(options)
	{
		public DbSet<Employee> Employees => Set<Employee>();
		public DbSet<Project> Projects => Set<Project>();
		public DbSet<ProjectTask> ProjectTasks => Set<ProjectTask>();
		public DbSet<ProjectEmployee> ProjectEmployees => Set<ProjectEmployee>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProjectEmployee>()
				.HasKey(pe => new { pe.ProjectId, pe.EmployeeId });

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
