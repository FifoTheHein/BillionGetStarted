using Microsoft.EntityFrameworkCore.Migrations;

namespace Geography.Migrations
{
    public partial class AddTimezones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Timezones",
                columns: table => new
                {
                    TimeZoneId = table.Column<string>(maxLength: 40, nullable: false),
                    CountryCode = table.Column<string>(maxLength: 2, nullable: true),
                    GMTOffset = table.Column<double>(nullable: false),
                    DSTOffset = table.Column<double>(nullable: false),
                    RawOffset = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timezones", x => x.TimeZoneId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timezones");
        }
    }
}
