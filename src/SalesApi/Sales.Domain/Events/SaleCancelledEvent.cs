using Sales.Domain.Enums;

namespace Sales.Domain.Events
{
    public record SaleCancelledEvent : IntegrationEvent
    {
        public Guid SaleId { get; init; }
        public Guid CustomerId { get; init; }
        public DateTime CancelledAt { get; init; }
        
        public StatusSale StatusSale  { get; set; }

    }
}