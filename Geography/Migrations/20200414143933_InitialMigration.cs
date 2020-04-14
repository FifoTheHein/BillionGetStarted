using Microsoft.EntityFrameworkCore.Migrations;

namespace Geography.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ISO = table.Column<string>(maxLength: 2, nullable: false),
                    ISO3 = table.Column<string>(maxLength: 3, nullable: true),
                    FIPS = table.Column<string>(maxLength: 2, nullable: true),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    Capital = table.Column<string>(maxLength: 200, nullable: true),
                    Continent = table.Column<string>(maxLength: 20, nullable: true),
                    CurrencyCode = table.Column<string>(maxLength: 3, nullable: true),
                    CurrencyName = table.Column<string>(maxLength: 20, nullable: true),
                    PhonePrefix = table.Column<string>(maxLength: 10, nullable: true),
                    Languages = table.Column<string>(maxLength: 100, nullable: true),
                    geonameid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ISO);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
