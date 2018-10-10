using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressAPI3.EFData.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Postcode = table.Column<string>(maxLength: 10, nullable: false),
                    Town = table.Column<string>(maxLength: 30, nullable: false),
                    SubBuildingName = table.Column<string>(maxLength: 30, nullable: true),
                    BuildingName = table.Column<string>(maxLength: 50, nullable: true),
                    BuildingNumber = table.Column<string>(maxLength: 4, nullable: true),
                    Organisation = table.Column<string>(maxLength: 60, nullable: true),
                    Department = table.Column<string>(maxLength: 60, nullable: true),
                    POBox = table.Column<string>(maxLength: 6, nullable: true),
                    Thoroughfare = table.Column<string>(maxLength: 80, nullable: true),
                    ThoroughfareDependent = table.Column<string>(maxLength: 80, nullable: true),
                    Locality = table.Column<string>(maxLength: 35, nullable: true),
                    LocalityDependent = table.Column<string>(maxLength: 35, nullable: true),
                    UDPRN = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Postcodes",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 80, nullable: true),
                    Town = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postcodes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Postcodes");
        }
    }
}
