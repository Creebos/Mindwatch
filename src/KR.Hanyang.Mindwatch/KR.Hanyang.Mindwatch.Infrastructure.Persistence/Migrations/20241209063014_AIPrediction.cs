using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KR.Hanyang.Mindwatch.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AIPrediction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prediction",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prediction",
                table: "Answers");
        }
    }
}
