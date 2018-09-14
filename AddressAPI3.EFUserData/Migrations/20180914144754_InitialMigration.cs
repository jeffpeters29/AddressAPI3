using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressAPI3.EFUserData.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "PasswordHash", "Username" },
                values: new object[] { 1, "Eddie", "Eagle", "Da21ROPBNsSb3f3CzxgoxWX2YkMmLh8QmqeBiIZ4fXs=", "EE" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "PasswordHash", "Username" },
                values: new object[] { 2, "Freddie", "Flintoff", "B9tplMn7jIAnRdZseqRCvzGko0ZHFj7+B1IDQ4u1k/8=", "FF" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "PasswordHash", "Username" },
                values: new object[] { 3, "Graham", "Gooch", "/21TLJ9cxwyebxIAz2R92sxLU3beXJ4Jyihjdxsxu0E=", "GG" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
