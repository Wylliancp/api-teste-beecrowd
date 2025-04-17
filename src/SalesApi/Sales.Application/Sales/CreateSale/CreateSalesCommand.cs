using MediatR;
using Sales.Application.Validation;

namespace Sales.Application.Sales.CreateSale;

public record CreateSalesCommand : IRequest<CreateSalesResult>
{
    public CreateSalesCommand(Guid customerId,
        List<CreateSaleItemCommand> items)
    {
        CustomerId = customerId;
        Items = items;
    }
    public Guid CustomerId { get; private set; }
    public List<CreateSaleItemCommand> Items { get; set; }//ajustar
    
    public ValidationResponseDetail Validate()
    {
        var validator = new CreateSalesCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResponseDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}

public class CreateSaleItemCommand
{
    public CreateSaleItemCommand(Guid productId, decimal unitPrice, int quantity, string productName)
    {
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
        ProductName = productName;
    }

    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}