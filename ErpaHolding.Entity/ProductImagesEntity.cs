namespace ErpaHolding.Entity
{
    public class ProductImagesEntity:BaseEntity
    {
        public string ImagePath { get; set; }

        #region Navigation Property
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }
        #endregion
    }
}
