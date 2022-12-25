using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleBid2.Migrations
{
    public partial class setupdate08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "Trophies",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "TropName",
                table: "Trophies",
                newName: "Trop_Name");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Trophies",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Trop_Name",
                table: "Trophies",
                newName: "TropName");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Trophies",
                newName: "dateTime");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Trophies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
