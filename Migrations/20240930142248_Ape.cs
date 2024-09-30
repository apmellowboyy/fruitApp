using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bruhBruh.Migrations
{
    public partial class Ape : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_newFruit",
                table: "newFruit");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "newFruit",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "newFruit",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_newFruit",
                table: "newFruit",
                column: "Color");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_newFruit",
                table: "newFruit");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "newFruit",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "newFruit",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_newFruit",
                table: "newFruit",
                column: "Name");
        }
    }
}
