using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comp306GroupProject.Migrations
{
    /// <inheritdoc />
    public partial class AlterEmployeeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EducationExperience",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequiredSkills",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "EducationExperience",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "RequiredSkills",
                table: "Job");
        }
    }
}
