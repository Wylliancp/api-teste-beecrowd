using MediatR;
using Sales.Application.Validation;

namespace Sales.Application.Products.CreateProduct;

public record CreateProductsCommand : IRequest<CreateProductsResult>
{
    public CreateProductsCommand(string name, string category, string description, string imageFile, decimal price)
    {
        Name = name;
        Category = category;
        Description = description;
        ImageFile = imageFile;
        Price = price;
    }

    public string Name { get; set; } 
    public string Category { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }


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