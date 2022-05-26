using FluentValidation;

namespace OnlineShop.Application.App.Products.Commands
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty()
                .Length(3, 200);

            RuleFor(b => b.Description)
                .Length(5, int.MaxValue);

            RuleFor(b => b.ProductBrand)
                .NotEmpty();

            RuleFor(b => b.ProductBrandId)
                .NotEmpty();

            RuleFor(b => b.Price)
                .NotEmpty();

            RuleFor(b => b.ProductType)
                .NotEmpty();

            RuleFor(b => b.ProductTypeId)
                .NotEmpty();

            RuleFor(b => b.PictureUrl)
                .NotEmpty();

        }
    }
}
