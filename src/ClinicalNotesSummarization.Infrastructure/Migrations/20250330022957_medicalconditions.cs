using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicalNotesSummarization.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class medicalconditions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiagnosedOn",
                table: "MedicalConditions");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "MedicalConditions",
                newName: "Treatments");

            migrationBuilder.RenameColumn(
                name: "ConditionName",
                table: "MedicalConditions",
                newName: "Symptoms");

            migrationBuilder.AddColumn<string>(
                name: "Causes",
                table: "MedicalConditions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MedicalConditions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MedicalConditions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Severity",
                table: "MedicalConditions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Causes",
                table: "MedicalConditions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MedicalConditions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MedicalConditions");

            migrationBuilder.DropColumn(
                name: "Severity",
                table: "MedicalConditions");

            migrationBuilder.RenameColumn(
                name: "Treatments",
                table: "MedicalConditions",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Symptoms",
                table: "MedicalConditions",
                newName: "ConditionName");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DiagnosedOn",
                table: "MedicalConditions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
