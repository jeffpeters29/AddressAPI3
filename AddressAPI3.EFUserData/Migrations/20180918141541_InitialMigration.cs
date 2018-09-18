using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressAPI3.EFUserData.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Referer = table.Column<string>(nullable: false),
                    Inserted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    Inserted = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "Inserted", "LastName", "PasswordHash", "Updated", "Username" },
                values: new object[] { 1, "Eddie", new DateTime(2018, 9, 18, 14, 15, 41, 13, DateTimeKind.Utc), "Eagle", "Da21ROPBNsSb3f3CzxgoxWX2YkMmLh8QmqeBiIZ4fXs=", new DateTime(2018, 9, 18, 14, 15, 41, 13, DateTimeKind.Utc), "EE" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "Inserted", "LastName", "PasswordHash", "Updated", "Username" },
                values: new object[] { 2, "Freddie", new DateTime(2018, 9, 18, 14, 15, 41, 13, DateTimeKind.Utc), "Flintoff", "B9tplMn7jIAnRdZseqRCvzGko0ZHFj7+B1IDQ4u1k/8=", new DateTime(2018, 9, 18, 14, 15, 41, 13, DateTimeKind.Utc), "FF" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "Inserted", "LastName", "PasswordHash", "Updated", "Username" },
                values: new object[] { 3, "Graham", new DateTime(2018, 9, 18, 14, 15, 41, 13, DateTimeKind.Utc), "Gooch", "/21TLJ9cxwyebxIAz2R92sxLU3beXJ4Jyihjdxsxu0E=", new DateTime(2018, 9, 18, 14, 15, 41, 13, DateTimeKind.Utc), "GG" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
