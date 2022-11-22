using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleBid2.Migrations
{
    public partial class db002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CotractNo",
                table: "players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Managers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ContectNo",
                table: "Managers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "players");

            migrationBuilder.DropColumn(
                name: "CotractNo",
                table: "players");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "ContectNo",
                table: "Managers");
        }
    }
}
