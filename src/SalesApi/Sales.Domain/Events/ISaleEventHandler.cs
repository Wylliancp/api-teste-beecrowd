using Sales.Domain.Enums;

namespace Sales.Domain.Events;

public interface ISaleEventHandler
{
      Task PublishSaleCreatedEvent(Guid saleId, Guid customerId, DateTime createdAt,
            CancellationToken cancellationToken);

      Task PublishSaleCancelledEvent(Guid saleId, DateTime cancelledAt, StatusSale statusSale,
            CancellationToken cancellationToken);

      Task PublishSaleItemCancelledEvent(Guid itemId, Guid saleId, DateTime cancelledAt,
            StatusSale statusSale, CancellationToken cancellationToken);
}