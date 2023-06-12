using ErpaHolding.Business.DTOs.BrandDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHolding.Business.Validations.BrandValidation
{
    public class BrandUpdateValidation:AbstractValidator<BrandUpdateDto>
    {
        public BrandUpdateValidation()
        {
            RuleFor(x => x.Defination).NotNull().NotEmpty().WithMessage("Bu alan boş geçilemez");
        }
        
    }
}
