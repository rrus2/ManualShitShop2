using Microsoft.EntityFrameworkCore.Migrations;

namespace ManualShitShop2.Migrations
{
    public partial class AddedKeyOrderID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Orders_OrderID",
                table: "Orders",
                column: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Orders_OrderID",
                table: "Orders");
        }
    }
}
