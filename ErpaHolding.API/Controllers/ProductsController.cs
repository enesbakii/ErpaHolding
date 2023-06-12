using ErpaHolding.API.Models;
using ErpaHolding.Business.DTOs.ProductDto;
using ErpaHolding.Business.DTOs.ProductImagesDto;
using ErpaHolding.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErpaHolding.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProdutImagesService _productImagesService;
        private readonly IWebHostEnvironment _environment;

        public ProductsController(IProductService productService, IWebHostEnvironment environment, IProdutImagesService productImagesService)
        {
            _productService = productService;
            _environment = environment;
            _productImagesService = productImagesService;
        }


        [Authorize(Roles = "admin,member")]
        [HttpPost]
        public async Task<IActionResult> SaveWithImages([FromForm] ProductModel productModel)
        {

            var productCreateDto = new ProductCreateDto()
            {
                BrandId = productModel.BrandId,
                CategoryId = productModel.CategoryId,
                Description = productModel.Description,
                Name = productModel.Name,
                Price = productModel.Price,
                UnitInStock = productModel.UnitInStock,
                ModelId = productModel.ModelId,
            };

            var productCreateResponse = await _productService.CreateAsync(productCreateDto);

            var productImageList = new List<ProductImagesCreateDto>();

            if (productModel.ImagePaths.Any())
            {
                foreach(var path in productModel.ImagePaths)
                {
                    var newFileName = "";

                    var allowedFileContentType = new string[]
                                   {
                   "image/jpeg","image/jpg","image/png","image/jfif"
                                   };

                    var allowedFileExtensions = new string[]
                    {
                    ".jpg",".jpeg",".png",".jfif"
                    };

                    var fileContentType = path.ContentType;
                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path.FileName);
                    var fileExtension = Path.GetExtension(path.FileName);


                    if (!allowedFileContentType.Contains(fileContentType) || !allowedFileExtensions.Contains(fileExtension))
                    {

                        return BadRequest("Bu alan boş geçilemez");


                    }

                    newFileName = fileNameWithoutExtension + "-" + Guid.NewGuid() + fileExtension;

                    var folderPath = Path.Combine("images", "product");
                    var wwwRootFolderPath = Path.Combine(_environment.WebRootPath, folderPath);
                    var wwwRootFilePath = Path.Combine(wwwRootFolderPath, newFileName);

                    Directory.CreateDirectory(wwwRootFolderPath);

                    using (var fileStream = new FileStream(wwwRootFilePath, FileMode.Create))
                    {
                        path.CopyTo(fileStream);
                    }

                    productImageList.Add(
                        new ProductImagesCreateDto
                        {
                            ImagePath = newFileName,
                            ProductId = productCreateResponse.Data.Id
                        });                   
                }

                var response = await _productImagesService.CreateListAsync(productImageList);
                if (response.StatusCode != StatusCodes.Status200OK)
                {
                    return BadRequest(response.Errors);
                }
            }

            return Ok();
        }




        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var response = await _productService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _productService.GetByFilterAsync(id);
            if (response.StatusCode == StatusCodes.Status200OK)
            {
                return Ok(response);
            }
            return NotFound(response.Errors);
        }
        [Authorize(Roles = "admin,member")]
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            var response = await _productService.UpdateAsync(productUpdateDto);
            if (response.StatusCode != StatusCodes.Status204NoContent)
            {
                return BadRequest(response.Errors);
            }
            return NoContent();

        }
        [Authorize(Roles = "admin,member")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var responce = await _productService.RemoveAsync(id);
            if (responce.StatusCode != StatusCodes.Status204NoContent)
            {
                return NotFound(responce.Errors);
            }
            return NoContent();
        }
    }
}
