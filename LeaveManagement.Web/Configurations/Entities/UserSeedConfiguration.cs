using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities
{
	public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			var hasher = new PasswordHasher<Employee>();

			builder.HasData(
				new Employee
				{
					Id = "5740b325-05e5-408b-84bd-24b97e795bfa",
					Email = "admin@localhost.com",
					NormalizedEmail = "ADMIN@LOCALHOST.COM",
					NormalizedUserName = "ADMIN@LOCALHOST.COM",
					UserName = "admin@localhost.com",
					FirstName = "System",
					LastName = "Admin",
					PasswordHash = hasher.HashPassword(null, "Admin$123"),
					EmailConfirmed = true
				},
				new Employee
				{
					Id = "5bea0f5e-64fd-4763-ba88-c9c090affb51",
					Email = "user@localhost.com",
					NormalizedEmail = "USER@LOCALHOST.COM",
					NormalizedUserName = "USER@LOCALHOST.COM",
					UserName = "user@localhost.com",
					FirstName = "System",
					LastName = "User",
					PasswordHash = hasher.HashPassword(null, "User$123"),
					EmailConfirmed = true
				}
			);
		}
	}
}
