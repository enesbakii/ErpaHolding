using ErpaHolding.Business.DTOs.CategoryDto;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHolding.Business.Validations.CategoryValidation
{
    public class CategoryCreateDtoValidation : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Ad alanı boş geçilemez");
        }
    }
}
