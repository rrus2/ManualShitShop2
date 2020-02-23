using Microsoft.EntityFrameworkCore.Migrations;

namespace ManualShitShop2.Migrations
{
    public partial class RemovedAmountFromProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Amount", "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
