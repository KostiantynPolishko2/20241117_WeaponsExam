using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminPageServer.PL.Migrations
{
    /// <inheritdoc />
    public partial class weapons_cards_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "weapons_properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "weapons_items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "weapons_properties");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "weapons_items");
        }
    }
}
