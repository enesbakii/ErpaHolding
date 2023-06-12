using ErpaHolding.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpaHolding.DataAccess.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetailsEntity>
    {

        public void Configure(EntityTypeBuilder<OrderDetailsEntity> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x=>x.ProductId).IsRequired();
            builder.Property(x=>x.OrderId).IsRequired();
            builder.Property(x=>x.Count).IsRequired();
            builder.Property(x=>x.Price).IsRequired();
        }
    }
}
