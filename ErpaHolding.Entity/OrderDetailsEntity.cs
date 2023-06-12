namespace ErpaHolding.Entity
{
    public class OrderDetailsEntity:BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }

        #region Navigation Properties
        public OrderEntity Order { get; set; }
        public ProductEntity Product { get; set; }
        #endregion

    }
}
