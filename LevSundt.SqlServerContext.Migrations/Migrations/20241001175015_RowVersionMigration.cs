using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LevSundt.SqlServerContext.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class RowVersionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "bmi",
                table: "Bmi");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "bmi",
                table: "Bmi",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "bmi",
                table: "Bmi");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "bmi",
                table: "Bmi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
