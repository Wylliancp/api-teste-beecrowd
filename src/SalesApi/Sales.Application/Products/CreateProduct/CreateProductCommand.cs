using MediatR;
using Sales.Application.Validation;

namespace Sales.Application.Products.CreateProduct;

public record CreateProductCommand : IRequest<CreateProductResult>
{
    public CreateProductCommand(string name, string category, string description, string imageFile, decimal price)
    {
        Name = name;
        Category = category;
        Description = description;
        ImageFile = imageFile;
        Price = price;
    }

    public string Name { get; init; } 
    public string Category { get; init; }
    public string Description { get; init; }
    public string ImageFile { get; init; }
    public decimal Price { get; init; }


    public ValidationResponseDetail Validate()
    {
        var validator = new CreateProductsCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResponseDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}