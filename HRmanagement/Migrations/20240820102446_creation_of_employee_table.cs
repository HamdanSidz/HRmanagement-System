using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRmanagement.Migrations
{
    /// <inheritdoc />
    public partial class creation_of_employee_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Emp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Emp_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emp_Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emp_email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Emp_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
