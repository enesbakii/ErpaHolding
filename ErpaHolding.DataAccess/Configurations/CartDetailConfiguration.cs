using ErpaHolding.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpaHolding.DataAccess.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetailsEntity>
    {
        public void Configure(EntityTypeBuilder<CartDetailsEntity> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.CartId).IsRequired();
            builder.Property(x=>x.Count).IsRequired();
        }
    }
}
