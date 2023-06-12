using ErpaHolding.Business.DTOs.ProductImagesDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHolding.Business.Validations.ProductImageValidation
{
    public class ProductImagesUpdateDtoValidation:AbstractValidator<ProductImagesUpdateDto>
    {
        public ProductImagesUpdateDtoValidation()
        {
            RuleFor(x => x.ProductId).NotNull().NotEmpty().WithMessage("Bu alan boş geçilemez");
        }
    }
}
