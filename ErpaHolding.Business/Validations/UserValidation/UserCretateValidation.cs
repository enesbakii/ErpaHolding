using ErpaHolding.Business.DTOs.UserDto;
using ErpaHolding.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHolding.Business.Validations.UserValidation
{
    public class UserCretateValidation:AbstractValidator<UserCreateDto>
    {
        public UserCretateValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.IdentityNumber).Length(11).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Bu alan boş geçilemez");

        }
    }
}
