using Business.Features.Auth.Commands.Register;
using FluentValidation;

namespace Business.Features.Auth.Validations
{
	public class RegisterValidator : AbstractValidator<RegisterCommand>
	{
        public RegisterValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(3).MaximumLength(20);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(3).MaximumLength(20);
        }
    }
}
