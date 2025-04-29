using MediatR;
using Sales.Application.Validation;

namespace Sales.Application.Sales.CreateSale;

public record CreateSaleCommand : IRequest<CreateSaleResult>
{
    public CreateSaleCommand(Guid customerId,
        List<CreateSaleItemCommand> items)
    {
        CustomerId = customerId;
        Items = items;
    }
    public Guid CustomerId { get; private set; }
    public List<CreateSaleItemCommand> Items { get; init; }//ajustar
    
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
    public CreateSaleItemCommand(Guid saleId, Guid productId, string productName, int quantity, decimal valueMonetaryTaxApplied, decimal unitPrice)
    {
        SaleId = saleId;
        ProductId = productId;
        ProductName = productName;
        UnitPrice = unitPrice;
        ValueMonetaryTaxApplied = valueMonetaryTaxApplied;
        Quantity = quantity;
    }

    public Guid SaleId { get; init; }
    public Guid ProductId { get; init; }
    public string ProductName { get; init; }
    public int Quantity { get; init; }
    public decimal ValueMonetaryTaxApplied { get; init; }
    public decimal UnitPrice { get; init; }
}