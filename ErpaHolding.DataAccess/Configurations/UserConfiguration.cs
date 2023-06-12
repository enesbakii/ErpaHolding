using ErpaHolding.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpaHolding.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x=>x.IdentityNumber).IsRequired()
                .HasMaxLength(11);
            builder.Property(x=>x.UserName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x=>x.FirstName).IsRequired();
            builder.Property(x=>x.LastName).IsRequired();
            builder.Property(x=>x.Password).IsRequired();
          

        }
    }
}
