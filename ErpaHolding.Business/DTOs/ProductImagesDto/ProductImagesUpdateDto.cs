namespace ErpaHolding.Business.DTOs.ProductImagesDto
{
    public class ProductImagesUpdateDto
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public Guid ProductId { get; set; }
    }
}
