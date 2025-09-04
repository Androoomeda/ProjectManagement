using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Migrations
{
    /// <inheritdoc />
    public partial class changeprojectemployeetosinglekey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			// Добавляем временный столбец с Identity
			migrationBuilder.AddColumn<int>(
				name: "NewId",
				table: "ProjectEmployees",
				type: "int",
				nullable: false,
				defaultValue: 0)
				.Annotation("SqlServer:Identity", "1, 1");

			// Удаляем старый PK
			migrationBuilder.DropPrimaryKey(
				name: "PK_ProjectEmployees",
				table: "ProjectEmployees");

			// Удаляем старый столбец Id
			migrationBuilder.DropColumn(
				name: "Id",
				table: "ProjectEmployees");

			// Переименовываем NewId в Id
			migrationBuilder.RenameColumn(
				name: "NewId",
				table: "ProjectEmployees",
				newName: "Id");

			// Добавляем новый PK на Id
			migrationBuilder.AddPrimaryKey(
				name: "PK_ProjectEmployees",
				table: "ProjectEmployees",
				column: "Id");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectEmployees",
                table: "ProjectEmployees");

            migrationBuilder.DropIndex(
                name: "IX_ProjectEmployees_ProjectId",
                table: "ProjectEmployees");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProjectEmployees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectEmployees",
                table: "ProjectEmployees",
                columns: new[] { "ProjectId", "EmployeeId" });
        }
    }
}
