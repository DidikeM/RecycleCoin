using FluentValidation;
using FluentValidation.AspNetCore;
using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.ValidationRules
{
    public class RegisterValidator:AbstractValidator<User>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty")
                                  .MinimumLength(8).WithMessage("Please enter at least eight character");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty")
                               .EmailAddress().WithMessage("A valid email is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty")
                                    .MinimumLength(8).WithMessage("Please enter at least eight character");
        }
    }
}
