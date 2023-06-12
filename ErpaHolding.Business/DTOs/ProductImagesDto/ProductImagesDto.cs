namespace ErpaHolding.Business.DTOs.ProductImagesDto
{
    public class ProductImagesDto
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public Guid ProductId { get; set; }
    }
}
