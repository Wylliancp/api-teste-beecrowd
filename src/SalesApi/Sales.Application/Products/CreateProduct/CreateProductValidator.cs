using FluentValidation;

namespace Sales.Application.Products.CreateProduct;

public class CreateProductsCommandValidator : AbstractValidator<CreateProductCommand>
{

    public CreateProductsCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}