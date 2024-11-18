using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleRpgEntities.Migrations
{
    public partial class AddEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerAbilities_Abilities_AbilitiesId",
                table: "PlayerAbilities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abilities",
                table: "Abilities");

            migrationBuilder.RenameTable(
                name: "Abilities",
                newName: "Ability");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ability",
                table: "Ability",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaponId = table.Column<int>(type: "int", nullable: true),
                    ArmorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Item_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Item",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipment_Item_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Item",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_EquipmentId",
                table: "Players",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_ArmorId",
                table: "Equipment",
                column: "ArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_WeaponId",
                table: "Equipment",
                column: "WeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerAbilities_Ability_AbilitiesId",
                table: "PlayerAbilities",
                column: "AbilitiesId",
                principalTable: "Ability",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Equipment_EquipmentId",
                table: "Players",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerAbilities_Ability_AbilitiesId",
                table: "PlayerAbilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Equipment_EquipmentId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Players_EquipmentId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ability",
                table: "Ability");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "Ability",
                newName: "Abilities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abilities",
                table: "Abilities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerAbilities_Abilities_AbilitiesId",
                table: "PlayerAbilities",
                column: "AbilitiesId",
                principalTable: "Abilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
