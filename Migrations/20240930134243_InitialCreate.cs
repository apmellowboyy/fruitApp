using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bruhBruh.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "newFruit",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newFruit", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "newFruit",
                columns: new[] { "Name", "Color", "Size", "Value" },
                values: new object[] { "Apple", "Red", "Small", 2 });

            migrationBuilder.InsertData(
                table: "newFruit",
                columns: new[] { "Name", "Color", "Size", "Value" },
                values: new object[] { "Banana", "Yellow", "Long", 3 });

            migrationBuilder.InsertData(
                table: "newFruit",
                columns: new[] { "Name", "Color", "Size", "Value" },
                values: new object[] { "Mango", "Greenish", "Medium", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "newFruit");
        }
    }
}
