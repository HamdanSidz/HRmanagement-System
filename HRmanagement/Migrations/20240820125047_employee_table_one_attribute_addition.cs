using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRmanagement.Migrations
{
    /// <inheritdoc />
    public partial class employee_table_one_attribute_addition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Emp_email",
                table: "Employees",
                newName: "Emp_Email");

            migrationBuilder.AddColumn<string>(
                name: "Emp_Phone",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emp_Phone",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Emp_Email",
                table: "Employees",
                newName: "Emp_email");
        }
    }
}
