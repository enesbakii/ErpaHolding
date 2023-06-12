namespace ErpaHolding.Entity
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int UnitInStock { get; set; }


        #region Navigation Properties
        public Guid CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public Guid ModelId { get; set; }
        public ModelEntity Model { get; set; }
        public Guid BrandId { get; set; }
        public BrandEntity Brand { get; set; }
        public List<OrderDetailsEntity> OrderDetails { get; set; }
        public List<CartDetailsEntity> CartDetails { get; set; }
        public List<ProductImagesEntity> ProductImages { get; set; }
        #endregion


    }
}