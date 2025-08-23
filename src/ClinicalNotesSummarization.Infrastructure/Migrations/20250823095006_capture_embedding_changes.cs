using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicalNotesSummarization.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class capture_embedding_changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmbeddingHash",
                table: "Medications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EmbeddingIndexedAt",
                table: "Medications",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmbeddingHash",
                table: "MedicalConditions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EmbeddingIndexedAt",
                table: "MedicalConditions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmbeddingHash",
                table: "Diagnoses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EmbeddingIndexedAt",
                table: "Diagnoses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmbeddingHash",
                table: "ClinicalNotes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EmbeddingIndexedAt",
                table: "ClinicalNotes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmbeddingHash",
                table: "Allergies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EmbeddingIndexedAt",
                table: "Allergies",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmbeddingHash",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "EmbeddingIndexedAt",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "EmbeddingHash",
                table: "MedicalConditions");

            migrationBuilder.DropColumn(
                name: "EmbeddingIndexedAt",
                table: "MedicalConditions");

            migrationBuilder.DropColumn(
                name: "EmbeddingHash",
                table: "Diagnoses");

            migrationBuilder.DropColumn(
                name: "EmbeddingIndexedAt",
                table: "Diagnoses");

            migrationBuilder.DropColumn(
                name: "EmbeddingHash",
                table: "ClinicalNotes");

            migrationBuilder.DropColumn(
                name: "EmbeddingIndexedAt",
                table: "ClinicalNotes");

            migrationBuilder.DropColumn(
                name: "EmbeddingHash",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "EmbeddingIndexedAt",
                table: "Allergies");
        }
    }
}
