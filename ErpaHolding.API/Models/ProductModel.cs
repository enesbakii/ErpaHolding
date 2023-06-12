using ErpaHolding.Business.DTOs.ProductImagesDto;

namespace ErpaHolding.API.Models
{
    public class ProductModel
    {
        public List<IFormFile> ImagePaths { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid BrandId { get; set; }
        public int UnitInStock { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ModelId { get; set; }
    }
}
