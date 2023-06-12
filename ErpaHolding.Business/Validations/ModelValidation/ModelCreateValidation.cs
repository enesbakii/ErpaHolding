using ErpaHolding.Business.DTOs.ModelDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHolding.Business.Validations.ModelValidation
{
    public class ModelCreateValidation:AbstractValidator<ModelCreateDto>
    {
        public ModelCreateValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez");
        }
    }
}
