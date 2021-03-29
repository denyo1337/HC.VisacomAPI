using FluentValidation;
using HotChocolateAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateAPI.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(HotChocolateDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(35);
            RuleFor(x => x.FirstName)
                .MinimumLength(1)
                .MaximumLength(35);
            RuleFor(x => x.LastName)
                .MinimumLength(1)
                .MaximumLength(35);
            RuleFor(x => x.Password)
                .MinimumLength(8);
            RuleFor(x => x.ConfirmPassword)
                .Equal(e => e.Password);
            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });
        }
    }
}
