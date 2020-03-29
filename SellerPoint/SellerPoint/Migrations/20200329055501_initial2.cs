using Microsoft.EntityFrameworkCore.Migrations;

namespace SellerPoint.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "ProductCategory");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "ProductCategory",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "ProductCategory");

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "ProductCategory",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
