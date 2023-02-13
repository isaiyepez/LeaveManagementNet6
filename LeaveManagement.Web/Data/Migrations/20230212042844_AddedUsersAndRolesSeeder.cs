using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
	public partial class AddedUsersAndRolesSeeder : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
				values: new object[,]
				{
					{ "6168e5bb-e84a-4dd7-b90c-0262aeb91ff1", "29e63af8-8813-4414-a6cc-ee868d4b1a95", "Administrator", "ADMINISTRATOR" },
					{ "6168e5cc-e84a-4dd5-b90c-0262aeb91ff1", "9332d611-284b-4c97-98a2-3dccd5003aa9", "User", "USER" }
				});

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
				values: new object[,]
				{
					{ "5740b325-05e5-408b-84bd-24b97e795bfa", 0, "61e0194f-9e94-4dd0-a457-121981619b53", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", false, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAED2+elq0iofgBUM41AdMOkNJKsIBSegE9viTOjP97zMgAT2nFlgC4q+uClRkEKJHew==", null, false, "6dbf53a9-0e22-4f26-a139-c77cee58384c", null, false, null },
					{ "5bea0f5e-64fd-4763-ba88-c9c090affb51", 0, "6829e2c5-2200-4fd9-992b-755258211348", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", false, "System", "User", false, null, "USER@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAEEWPssFvDSGqJVir3Y9g+kM9oP8wL6E2bozkWLb8QNAIiaF8UYGfJVBGkciXOEUCxw==", null, false, "b59d2611-1f99-4765-b111-8b28fac22ebe", null, false, null }
				});

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "RoleId", "UserId" },
				values: new object[] { "6168e5bb-e84a-4dd7-b90c-0262aeb91ff1", "5740b325-05e5-408b-84bd-24b97e795bfa" });

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "RoleId", "UserId" },
				values: new object[] { "6168e5cc-e84a-4dd5-b90c-0262aeb91ff1", "5bea0f5e-64fd-4763-ba88-c9c090affb51" });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { "6168e5bb-e84a-4dd7-b90c-0262aeb91ff1", "5740b325-05e5-408b-84bd-24b97e795bfa" });

			migrationBuilder.DeleteData(
				table: "AspNetUserRoles",
				keyColumns: new[] { "RoleId", "UserId" },
				keyValues: new object[] { "6168e5cc-e84a-4dd5-b90c-0262aeb91ff1", "5bea0f5e-64fd-4763-ba88-c9c090affb51" });

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "6168e5bb-e84a-4dd7-b90c-0262aeb91ff1");

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: "6168e5cc-e84a-4dd5-b90c-0262aeb91ff1");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "5740b325-05e5-408b-84bd-24b97e795bfa");

			migrationBuilder.DeleteData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "5bea0f5e-64fd-4763-ba88-c9c090affb51");
		}
	}
}
