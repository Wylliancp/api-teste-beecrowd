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
    public CreateSaleItemCommand(Guid saleId, Guid productId, string productName, int quantity, decimal valueMonetaryTaxApplied, decimal unitPrice)
    {
        SaleId = saleId;
        ProductId = productId;
        ProductName = productName;
        UnitPrice = unitPrice;
        ValueMonetaryTaxApplied = valueMonetaryTaxApplied;
        Quantity = quantity;
    }

    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal ValueMonetaryTaxApplied { get; set; }
    public decimal UnitPrice { get; set; }
}