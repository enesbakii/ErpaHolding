namespace ErpaHolding.Entity
{
    public class CartDetailsEntity:BaseEntity
    {
        public Guid CartId { get; set; }
        
        public Guid ProductId { get; set; }
        
        public int Count { get; set; }
        public DateTime CreatedDate { get; set; }


        #region Navigation Properties
        public CartEntity Cart { get; set; }

        public ProductEntity Product { get; set; }
        #endregion

    }
}
