using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedMissingFieldsUsersAndRolesSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6168e5bb-e84a-4dd7-b90c-0262aeb91ff1",
                column: "ConcurrencyStamp",
                value: "1d466b0d-2035-46f7-845e-60f4f1826b1f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6168e5cc-e84a-4dd5-b90c-0262aeb91ff1",
                column: "ConcurrencyStamp",
                value: "632c8ecc-739e-48d0-a06e-1dce5a90ad74");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5740b325-05e5-408b-84bd-24b97e795bfa",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "3a96011f-0b4c-4af3-a541-0f6e41ebbbe4", true, "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAENfmTls70EasLeP45jh1XgFcFGRsLh8mCTANGqYwP98WCizvHkX2WoV6H78WXvYMOA==", "bcc38f1c-4079-4d15-9c7e-5b7e404fa7f1", "admin@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bea0f5e-64fd-4763-ba88-c9c090affb51",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "85c4ed7c-bfce-430d-8318-45f3dc8defc6", true, "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEAk16Tz8+pPSZoRqg1z3iDJzBKKW4aak/aqMtdOSos1ygbvourbP5KcJOjg2s70PGQ==", "50a89bb9-f0a7-4a19-8a95-42a1cacf86de", "user@localhost.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6168e5bb-e84a-4dd7-b90c-0262aeb91ff1",
                column: "ConcurrencyStamp",
                value: "29e63af8-8813-4414-a6cc-ee868d4b1a95");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6168e5cc-e84a-4dd5-b90c-0262aeb91ff1",
                column: "ConcurrencyStamp",
                value: "9332d611-284b-4c97-98a2-3dccd5003aa9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5740b325-05e5-408b-84bd-24b97e795bfa",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "61e0194f-9e94-4dd0-a457-121981619b53", false, null, "AQAAAAEAACcQAAAAED2+elq0iofgBUM41AdMOkNJKsIBSegE9viTOjP97zMgAT2nFlgC4q+uClRkEKJHew==", "6dbf53a9-0e22-4f26-a139-c77cee58384c", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bea0f5e-64fd-4763-ba88-c9c090affb51",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6829e2c5-2200-4fd9-992b-755258211348", false, null, "AQAAAAEAACcQAAAAEEWPssFvDSGqJVir3Y9g+kM9oP8wL6E2bozkWLb8QNAIiaF8UYGfJVBGkciXOEUCxw==", "b59d2611-1f99-4765-b111-8b28fac22ebe", null });
        }
    }
}
