using ErpaHolding.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ErpaHolding.DataAccess.Configurations
{
    public class OrderConfiguriton : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.OrderTotal).IsRequired();
            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.CartTotalItems).IsRequired();

        }
    }
}
