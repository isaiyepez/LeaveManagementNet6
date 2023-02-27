using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class UpdatedRequestedComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6168e5bb-e84a-4dd7-b90c-0262aeb91ff1",
                column: "ConcurrencyStamp",
                value: "1ea4df12-2f44-469e-8684-97d846444e28");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6168e5cc-e84a-4dd5-b90c-0262aeb91ff1",
                column: "ConcurrencyStamp",
                value: "e689b557-b829-4299-80d6-ad5438660722");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5740b325-05e5-408b-84bd-24b97e795bfa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75bab1df-80cd-40cb-b8a9-308558bea5f8", "AQAAAAEAACcQAAAAEMyL4OIlyllFc4mFrTVoOTpc/ewUpoXo8XRv+WAHOnTZKh21O0nrB9Il7apn7M4Pkg==", "642ee0eb-6362-4cab-8897-d74e21ceec9b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bea0f5e-64fd-4763-ba88-c9c090affb51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "211a8303-34fb-4ace-b93f-ffe88c6b71e7", "AQAAAAEAACcQAAAAEF1swCJbd1Dtb4d1PbmufgU36LrXuW+/tdpO3fLxEEaLY1MKrdom8uvt2eZyDIIhQA==", "f79144d4-11ba-463b-9178-8d013a69a46b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6168e5bb-e84a-4dd7-b90c-0262aeb91ff1",
                column: "ConcurrencyStamp",
                value: "9a4e61d5-362c-49a3-bbd7-29edba134701");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6168e5cc-e84a-4dd5-b90c-0262aeb91ff1",
                column: "ConcurrencyStamp",
                value: "bfa2e67f-7d18-4ece-b798-764076bcce7d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5740b325-05e5-408b-84bd-24b97e795bfa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3577e6ef-9af4-4ba9-93d4-c1604c3eeb7b", "AQAAAAEAACcQAAAAEG/4EJLKMmxDN0ED4hdg/tT8sBXWVYORfzG8xdi6WBFXK+YBPAHpTpk2Ky8XdJYmEA==", "31d0510e-a478-49d0-836d-3d244c54f50c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bea0f5e-64fd-4763-ba88-c9c090affb51",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "727d02df-aec6-450d-9a15-fcd5d4628388", "AQAAAAEAACcQAAAAEKMV6SZF7ESkZPpEBng8pTAtVRpcIN6UxtSHWRwrSDHUVpLNcZNwQHrMLRgAyUcR7A==", "d51c6062-d082-46f0-b9f4-fa9866c15aee" });
        }
    }
}
