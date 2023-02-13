using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities
{
	public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
		{
			builder.HasData(
				new IdentityUserRole<string>
				{
					RoleId = "6168e5bb-e84a-4dd7-b90c-0262aeb91ff1",
					UserId = "5740b325-05e5-408b-84bd-24b97e795bfa"
				},
				new IdentityUserRole<string>
				{
					RoleId = "6168e5cc-e84a-4dd5-b90c-0262aeb91ff1",
					UserId = "5bea0f5e-64fd-4763-ba88-c9c090affb51"
				}
			);
		}
	}
}
