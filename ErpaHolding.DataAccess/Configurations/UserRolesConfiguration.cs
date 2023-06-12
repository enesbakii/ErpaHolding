using ErpaHolding.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpaHolding.DataAccess.Configurations
{
    public class UserRolesConfiguration : IEntityTypeConfiguration<UserRolesEntity>
    {
        public void Configure(EntityTypeBuilder<UserRolesEntity> builder)
        {
            builder.Ignore("Id");
            builder.HasKey("UserId", "RoleId");
        }
    }
}
