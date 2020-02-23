using Microsoft.EntityFrameworkCore.Migrations;

namespace ManualShitShop2.Migrations
{
    public partial class AddedImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                nullable: true);
            migrationBuilder.AddColumn<int>("Amount", "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");
            migrationBuilder.DropColumn("Amount", "Products");
        }
    }
}
