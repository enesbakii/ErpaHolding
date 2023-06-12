using ErpaHolding.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpaHolding.DataAccess.Configurations
{
    public class ModelConfiguraiton : IEntityTypeConfiguration<ModelEntity>
    {
        public void Configure(EntityTypeBuilder<ModelEntity> builder)
        {
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
