namespace ProjectManagement
{
	using ProjectManagement.Data;
	using ProjectManagement.Services;

    /// <summary>
    /// The main entry point of the application.
    /// Configures services, middleware, and starts the web host.
    /// </summary>
	public class Program
    {
        /// <summary>
        /// Builds and rung the web application.
        /// Sets up dependency injeciton, routing, Swagger, HTTPS regirection, and authorization.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ProjectService>();
            builder.Services.AddScoped<EmployeeService>();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddSqlServer<ProjectManagementContext>(connectionString);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
