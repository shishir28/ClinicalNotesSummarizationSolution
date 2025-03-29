using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicalNotesSummarization.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class diagnosis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Diagnoses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrescribingDoctor",
                table: "Diagnoses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Severity",
                table: "Diagnoses",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Diagnoses");

            migrationBuilder.DropColumn(
                name: "PrescribingDoctor",
                table: "Diagnoses");

            migrationBuilder.DropColumn(
                name: "Severity",
                table: "Diagnoses");
        }
    }
}
