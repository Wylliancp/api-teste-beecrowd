using MassTransit;
using Sales.Domain.Enums;
using Sales.Domain.Events;

namespace Sales.Application.Events;

public class SaleEventHandler : ISaleEventHandler
{
    private readonly IPublishEndpoint _publishEndpoint;

    public SaleEventHandler(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task PublishSaleCreatedEvent(Guid saleId, Guid customerId, DateTime createdAt, CancellationToken cancellationToken)
    {
        var eventMessage = new SaleCreatedEvent
        {
            SaleId = saleId,
            CustomerId = customerId,
            CreatedAt = createdAt
        };

        await _publishEndpoint.Publish(eventMessage, cancellationToken);
    }

    public async Task PublishSaleCancelledEvent(Guid saleId, DateTime cancelledAt, StatusSale statusSale, CancellationToken cancellationToken)
    {
        var eventMessage = new SaleCancelledEvent
        {
            SaleId = saleId,
            CancelledAt = cancelledAt,
            StatusSale = statusSale
        };

        await _publishEndpoint.Publish(eventMessage, cancellationToken);
    }

    public async Task PublishSaleItemCancelledEvent(Guid itemId, Guid saleId, DateTime cancelledAt, StatusSale statusSale, CancellationToken cancellationToken)
    {
        var eventMessage = new SaleItemCancelledEvent
        {
            ItemId = itemId,
            SaleId = saleId,
            CancelledAt = cancelledAt,
            StatusSale = statusSale
        };

        await _publishEndpoint.Publish(eventMessage, cancellationToken);
    }
}

