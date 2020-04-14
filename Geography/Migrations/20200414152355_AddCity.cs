using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Geography.Migrations
{
    public partial class AddCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<Guid>(nullable: false),
                    geonameid = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    ASCIITitle = table.Column<string>(maxLength: 200, nullable: true),
                    AlternateTitles = table.Column<string>(maxLength: 10000, nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    CountryCode = table.Column<string>(maxLength: 2, nullable: true),
                    Timezone = table.Column<string>(maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
