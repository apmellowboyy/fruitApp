using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bruhBruh.Migrations.Veggie
{
    public partial class InitialVeggieMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veggies",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veggies", x => x.Name);
                });

            migrationBuilder.InsertData(
                table: "Veggies",
                columns: new[] { "Name", "Size", "Value", "Weight" },
                values: new object[] { "Celery", "Long", 2, 1 });

            migrationBuilder.InsertData(
                table: "Veggies",
                columns: new[] { "Name", "Size", "Value", "Weight" },
                values: new object[] { "Green Pepper", "Wide", 3, 2 });

            migrationBuilder.InsertData(
                table: "Veggies",
                columns: new[] { "Name", "Size", "Value", "Weight" },
                values: new object[] { "Habanero", "Small", 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veggies");
        }
    }
}
