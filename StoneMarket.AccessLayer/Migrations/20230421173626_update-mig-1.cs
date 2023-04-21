using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoneMarket.AccessLayer.Migrations
{
    public partial class updatemig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Createdate",
                table: "Redirections",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Createdate",
                table: "Redirections");
        }
    }
}
