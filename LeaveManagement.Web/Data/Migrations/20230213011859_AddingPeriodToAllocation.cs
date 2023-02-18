using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddingPeriodToAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6168e5bb-e84a-4dd7-b90c-0262aeb91ff1",
                column: "ConcurrencyStamp",
                value: "75238208-5233-4dd9-8776-9129d3006915");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6168e5cc-e84a-4dd5-b90c-0262aeb91ff1",
                column: "ConcurrencyStamp",
                value: "2298ed80-c6a6-4138-b120-4e07bba7f916");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5740b325-05e5-408b-84bd-24b97e795bfa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0051bb91-5071-47c7-b0c5-6b90df024b6f", "AQAAAAEAACcQAAAAEGr2LO3H0Fp3/MzcsbXco+Q0KPgW6p/LoMBU2+SUtlY9FuOtxHUxune+KAHeRuJVTA==", "7fd5023b-a7ad-4e6b-a22c-bfd89a17a7c8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bea0f5e-64fd-4763-ba88-c9c090affb51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6dab239-476e-4082-9218-e3fbffe5eb1b", "AQAAAAEAACcQAAAAEJbSqyG3fMpw+tEtLe97a06wEU3D0glI3Mjlu7eawz9QnB1oaFOkcrjZKj6ctVIv1g==", "77e01e0e-2238-4434-b00e-b79fb99e98e2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a96011f-0b4c-4af3-a541-0f6e41ebbbe4", "AQAAAAEAACcQAAAAENfmTls70EasLeP45jh1XgFcFGRsLh8mCTANGqYwP98WCizvHkX2WoV6H78WXvYMOA==", "bcc38f1c-4079-4d15-9c7e-5b7e404fa7f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bea0f5e-64fd-4763-ba88-c9c090affb51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85c4ed7c-bfce-430d-8318-45f3dc8defc6", "AQAAAAEAACcQAAAAEAk16Tz8+pPSZoRqg1z3iDJzBKKW4aak/aqMtdOSos1ygbvourbP5KcJOjg2s70PGQ==", "50a89bb9-f0a7-4a19-8a95-42a1cacf86de" });
        }
    }
}
