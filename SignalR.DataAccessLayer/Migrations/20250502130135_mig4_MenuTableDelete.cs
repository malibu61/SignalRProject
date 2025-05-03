using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class mig4_MenuTableDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_MenuTables_MenuTableID",
                table: "Baskets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuTables",
                table: "MenuTables");

            migrationBuilder.RenameTable(
                name: "MenuTables",
                newName: "MenuTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuTable",
                table: "MenuTable",
                column: "MenuTableID");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_MenuTable_MenuTableID",
                table: "Baskets",
                column: "MenuTableID",
                principalTable: "MenuTable",
                principalColumn: "MenuTableID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_MenuTable_MenuTableID",
                table: "Baskets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuTable",
                table: "MenuTable");

            migrationBuilder.RenameTable(
                name: "MenuTable",
                newName: "MenuTables");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuTables",
                table: "MenuTables",
                column: "MenuTableID");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_MenuTables_MenuTableID",
                table: "Baskets",
                column: "MenuTableID",
                principalTable: "MenuTables",
                principalColumn: "MenuTableID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
