using ErpaHolding.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpaHolding.DataAccess.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImagesEntity>
    {
        public void Configure(EntityTypeBuilder<ProductImagesEntity> builder)
        {
            builder.Property(x => x.ImagePath).IsRequired();
        }
    }
}
