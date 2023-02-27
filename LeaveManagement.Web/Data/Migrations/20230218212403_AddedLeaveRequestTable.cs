using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
    }
}
