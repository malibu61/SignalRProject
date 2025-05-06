using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_MenuTables_MenuTableID",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_StoreTables_StoreTableID",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_MenuTableID",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "MenuTableID",
                table: "Baskets");

            migrationBuilder.AlterColumn<int>(
                name: "StoreTableID",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_StoreTables_StoreTableID",
                table: "Baskets",
                column: "StoreTableID",
                principalTable: "StoreTables",
                principalColumn: "StoreTableID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_StoreTables_StoreTableID",
                table: "Baskets");

            migrationBuilder.AlterColumn<int>(
                name: "StoreTableID",
                table: "Baskets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MenuTableID",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_MenuTableID",
                table: "Baskets",
                column: "MenuTableID");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_MenuTables_MenuTableID",
                table: "Baskets",
                column: "MenuTableID",
                principalTable: "MenuTables",
                principalColumn: "StoreTableID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_StoreTables_StoreTableID",
                table: "Baskets",
                column: "StoreTableID",
                principalTable: "StoreTables",
                principalColumn: "StoreTableID");
        }
    }
}
