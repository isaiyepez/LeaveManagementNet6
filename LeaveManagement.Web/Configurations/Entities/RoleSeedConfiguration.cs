using LeaveManagement.Web.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities
{
	public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			builder.HasData(
				new IdentityRole
				{
					Id = "6168e5bb-e84a-4dd7-b90c-0262aeb91ff1",
					Name = Roles.Administrator,
					NormalizedName = Roles.Administrator.ToUpper()
				},
				new IdentityRole
				{
					Id = "6168e5cc-e84a-4dd5-b90c-0262aeb91ff1",
					Name = Roles.User,
					NormalizedName = Roles.User.ToUpper()
				}
			);
		}
	}
}