﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressAPI3.EFUserData.Migrations
{
    public partial class ActivityLogInserted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "Inserted", "LastName", "PasswordHash", "Updated", "Username" },
                values: new object[] { 1, "Eddie", new DateTime(2018, 9, 18, 15, 6, 46, 442, DateTimeKind.Utc), "Eagle", "Da21ROPBNsSb3f3CzxgoxWX2YkMmLh8QmqeBiIZ4fXs=", new DateTime(2018, 9, 18, 15, 6, 46, 442, DateTimeKind.Utc), "EE" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "Inserted", "LastName", "PasswordHash", "Updated", "Username" },
                values: new object[] { 2, "Freddie", new DateTime(2018, 9, 18, 15, 6, 46, 442, DateTimeKind.Utc), "Flintoff", "B9tplMn7jIAnRdZseqRCvzGko0ZHFj7+B1IDQ4u1k/8=", new DateTime(2018, 9, 18, 15, 6, 46, 442, DateTimeKind.Utc), "FF" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "Inserted", "LastName", "PasswordHash", "Updated", "Username" },
                values: new object[] { 3, "Graham", new DateTime(2018, 9, 18, 15, 6, 46, 442, DateTimeKind.Utc), "Gooch", "/21TLJ9cxwyebxIAz2R92sxLU3beXJ4Jyihjdxsxu0E=", new DateTime(2018, 9, 18, 15, 6, 46, 442, DateTimeKind.Utc), "GG" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "Inserted", "LastName", "PasswordHash", "Updated", "Username" },
                values: new object[] { 1, "Eddie", new DateTime(2018, 9, 18, 14, 50, 11, 512, DateTimeKind.Utc), "Eagle", "Da21ROPBNsSb3f3CzxgoxWX2YkMmLh8QmqeBiIZ4fXs=", new DateTime(2018, 9, 18, 14, 50, 11, 512, DateTimeKind.Utc), "EE" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "Inserted", "LastName", "PasswordHash", "Updated", "Username" },
                values: new object[] { 2, "Freddie", new DateTime(2018, 9, 18, 14, 50, 11, 512, DateTimeKind.Utc), "Flintoff", "B9tplMn7jIAnRdZseqRCvzGko0ZHFj7+B1IDQ4u1k/8=", new DateTime(2018, 9, 18, 14, 50, 11, 512, DateTimeKind.Utc), "FF" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "Inserted", "LastName", "PasswordHash", "Updated", "Username" },
                values: new object[] { 3, "Graham", new DateTime(2018, 9, 18, 14, 50, 11, 512, DateTimeKind.Utc), "Gooch", "/21TLJ9cxwyebxIAz2R92sxLU3beXJ4Jyihjdxsxu0E=", new DateTime(2018, 9, 18, 14, 50, 11, 512, DateTimeKind.Utc), "GG" });
        }
    }
}
