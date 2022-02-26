using Microsoft.EntityFrameworkCore.Migrations;

namespace REST.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Manufacturer", "Price", "Stock", "Type" },
                values: new object[] { 123456, "company1", 50.350000000000001, 10, "keyboard" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Manufacturer", "Price", "Stock", "Type" },
                values: new object[] { 444444, "company2", 39.0, 0, "keyboard" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Manufacturer", "Price", "Stock", "Type" },
                values: new object[] { 344324, "company1", 15.949999999999999, 2, "mouse" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
