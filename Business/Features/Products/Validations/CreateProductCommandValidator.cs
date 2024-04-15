using Business.Features.Products.Commands.Create;
using Entities.Concrete;
using FluentValidation;

namespace Business.Features.Products.Validations
{
	public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
	{
        public CreateProductCommandValidator()
        {
            RuleFor(x=>x.CategoryId).NotEmpty();
            RuleFor(x=>x.Name).NotEmpty().MinimumLength(3).MaximumLength(50).Must(StartsWithLetter).WithMessage("Ürün adı sayısal veya özel karakterle başlayamaz.");
            RuleFor(x => x.Stock).NotEmpty().GreaterThanOrEqualTo(1).LessThanOrEqualTo(1000);
            RuleFor(x => x.UnitPrice).NotEmpty().GreaterThanOrEqualTo(1).LessThanOrEqualTo(1000);
        }

		private bool StartsWithLetter(string name)
		{
			return !string.IsNullOrEmpty(name) && (char.IsLetter(name[0]));
		}
	}
}
