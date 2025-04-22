namespace Sales.Domain.Events
{
    public record SaleCreatedEvent : IntegrationEvent
    {
        public Guid SaleId { get; init; }
        public Guid CustomerId { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}