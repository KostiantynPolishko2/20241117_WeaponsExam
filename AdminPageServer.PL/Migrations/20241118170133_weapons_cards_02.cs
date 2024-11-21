using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminPageServer.PL.Migrations
{
    /// <inheritdoc />
    public partial class weapons_cards_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "weapons_images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_IdWeaponsItem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weapons_images", x => x.id);
                    table.ForeignKey(
                        name: "FK_weapons_images_weapons_items_FK_IdWeaponsItem",
                        column: x => x.FK_IdWeaponsItem,
                        principalTable: "weapons_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeaponsImage_idWeaponsItem",
                table: "weapons_images",
                column: "FK_IdWeaponsItem",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "weapons_images");
        }
    }
}
