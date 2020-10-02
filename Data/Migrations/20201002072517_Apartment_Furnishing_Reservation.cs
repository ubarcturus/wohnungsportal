using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wohnungsportal.Data.Migrations
{
    public partial class Apartment_Furnishing_Reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NRooms = table.Column<int>(nullable: false),
                    Furnishing = table.Column<int>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    PictureName = table.Column<string>(nullable: true),
                    Kitchen = table.Column<bool>(nullable: false),
                    Wlan = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Furnishing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kitchen = table.Column<byte>(nullable: false),
                    Wlan = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnishing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    IdentityUserId = table.Column<int>(nullable: false),
                    ApartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartment");

            migrationBuilder.DropTable(
                name: "Furnishing");

            migrationBuilder.DropTable(
                name: "Reservation");
        }
    }
}
