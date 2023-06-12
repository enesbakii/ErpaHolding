using ErpaHolding.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpaHolding.DataAccess.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasData(new List<RoleEntity>()
            {
               new RoleEntity()
               {
                   Id = Guid.NewGuid(),
                   Name = "admin",
               },
               new RoleEntity()
               {
                    Id = Guid.NewGuid(),
                   Name = "member",
               }
            });
                
              
        }
    }
}
