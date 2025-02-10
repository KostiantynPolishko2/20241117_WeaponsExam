using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminPageServer.PL.Migrations
{
    /// <inheritdoc />
    public partial class weapons_cards_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "weapons_properties",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<float>(type: "real", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_IdWeaponsItem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weapons_properties", x => x.id);
                    table.ForeignKey(
                        name: "FK_weapons_properties_weapons_items_FK_IdWeaponsItem",
                        column: x => x.FK_IdWeaponsItem,
                        principalTable: "weapons_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeaponsProperty_idWeaponsItem",
                table: "weapons_properties",
                column: "FK_IdWeaponsItem",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "weapons_properties");
        }
    }
}
