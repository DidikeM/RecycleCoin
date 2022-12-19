using FluentValidation;
using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.ValidationRules
{
    public class LoginValidator:AbstractValidator<User>
    {
        public LoginValidator()
        {
            RuleFor(x=> x.Email).NotEmpty().WithMessage("Email cannot be empty")
                                .EmailAddress().WithMessage("A valid email is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty")
                                    .MinimumLength(8).WithMessage("Please enter at least eight character");
        }
    }
}
