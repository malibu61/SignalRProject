using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreTableID",
                table: "Baskets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ProductID",
                table: "Baskets",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_StoreTableID",
                table: "Baskets",
                column: "StoreTableID");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Products_ProductID",
                table: "Baskets",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_StoreTables_StoreTableID",
                table: "Baskets",
                column: "StoreTableID",
                principalTable: "StoreTables",
                principalColumn: "StoreTableID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Products_ProductID",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_StoreTables_StoreTableID",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_ProductID",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_StoreTableID",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "StoreTableID",
                table: "Baskets");
        }
    }
}
