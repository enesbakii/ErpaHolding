using ErpaHolding.Business.DTOs.ProductDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHolding.Business.Validations.ProductValidation
{
    public class ProductUpdateDtoValidation:AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidation()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Price).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemz");
            RuleFor(x => x.BrandId).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemz");
            RuleFor(x => x.UnitInStock).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.CategoryId).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez");
        }
    }
}
