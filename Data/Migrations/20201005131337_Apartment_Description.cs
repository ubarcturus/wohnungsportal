using Microsoft.EntityFrameworkCore.Migrations;

namespace Wohnungsportal.Data.Migrations
{
    public partial class Apartment_Description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Furnishing");

            migrationBuilder.DropColumn(
                name: "Furnishing",
                table: "Apartment");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Apartment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Apartment");

            migrationBuilder.AddColumn<int>(
                name: "Furnishing",
                table: "Apartment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Furnishing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kitchen = table.Column<byte>(type: "tinyint", nullable: false),
                    Wlan = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnishing", x => x.Id);
                });
        }
    }
}
