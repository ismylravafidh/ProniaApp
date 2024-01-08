using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProniaApp.DAL.Migrations
{
    public partial class dshifvnosjdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrime",
                table: "Products",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrime",
                table: "Products");
        }
    }
}
