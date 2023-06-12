namespace ErpaHolding.Business.DTOs.ProductDto
{
    public class ProductCreateDto
    {
        public Guid Id { get; set; }
        public Guid ModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid BrandId { get; set; }
        public int UnitInStock { get; set; }
        public Guid CategoryId { get; set; }        
    }
}
