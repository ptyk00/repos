using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace zaj14
{
    class RegistrationModelValidator : AbstractValidator<RegistrationModel>
    {
        [Obsolete]
        public RegistrationModelValidator()
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(7)
                .Must(y => !(y == y.ToLower() || y == y.ToUpper()))
                .Matches(@"^(.*[!@#$%^&*].*)+");

            RuleFor(x => x.Accept)
                .Must(x => x)
                .WithMessage("Bardzo prosimy o zaakceptowanie regulaminu.");

        }
    }
}
