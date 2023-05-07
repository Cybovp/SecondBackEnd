using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecondBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class boolean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "KeepLoggedIn",
                table: "Tests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeepLoggedIn",
                table: "Tests");
        }
    }
}
