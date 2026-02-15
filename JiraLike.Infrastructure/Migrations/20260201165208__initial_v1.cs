using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JiraLike.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _initial_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PerformedByName",
                table: "ActivityLogs",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerformedByName",
                table: "ActivityLogs");
        }
    }
}
