using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProniaApp.DAL.Migrations
{
    public partial class dshifvn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProductImages",
                newName: "IsPrime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPrime",
                table: "ProductImages",
                newName: "IsDeleted");
        }
    }
}
