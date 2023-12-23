using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaleManagment.Server.Migrations
{
    /// <inheritdoc />
    public partial class addInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Element = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubElements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Windows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityOfWindows = table.Column<int>(type: "int", nullable: false),
                    TotalSubElements = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Windows", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { 1, "New York Building 1", "NY" },
                    { 2, "California Hotel AJK", "CA" }
                });

            migrationBuilder.InsertData(
                table: "SubElements",
                columns: new[] { "Id", "Element", "Height", "Type", "Width" },
                values: new object[,]
                {
                    { 1, 1, 2200, "Door", 1400 },
                    { 2, 1, 2200, "windo", 1400 }
                });

            migrationBuilder.InsertData(
                table: "Windows",
                columns: new[] { "Id", "Name", "QuantityOfWindows", "TotalSubElements" },
                values: new object[,]
                {
                    { 1, "GLB", 3, 2 },
                    { 2, "C Zone 5", 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "SubElements");

            migrationBuilder.DropTable(
                name: "Windows");
        }
    }
}
