using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicalNotesSummarization.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class missing_embedding_changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmbeddingHash",
                table: "Appointments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EmbeddingIndexedAt",
                table: "Appointments",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmbeddingHash",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "EmbeddingIndexedAt",
                table: "Appointments");
        }
    }
}
