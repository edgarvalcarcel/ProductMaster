namespace ProductMaster.Domain.Events;

public class ProductCreatedEvent(Product item) : BaseEvent
{
    public Product Item { get; } = item;
}
