using Microsoft.EntityFrameworkCore.Migrations;

namespace SellerPoint.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "ProductDetail");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductDetail",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductDetail");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ProductDetail",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
