using Sales.Domain.Enums;

namespace Sales.Domain.Events
{
    public record SaleItemCancelledEvent : IntegrationEvent
    {
        public Guid ItemId { get; init; }
        public Guid SaleId { get; init; }
        public Guid CustomerId { get; init; }
        
        public StatusSale StatusSale  { get; set; }
        public DateTime CancelledAt { get; init; }
    }
}