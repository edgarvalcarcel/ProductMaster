namespace ProductMaster.Domain.Entities;
public class Product: BaseEntity
{
    public int ProductId { get; set; }
    public required string Name { get; set; }
    public int StatusId { get; set; }
    public decimal Stock { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal? Discount { get; set; }
    public decimal FinalPrice { get; set; }

    private bool _done;
    public bool Done
    {
        get => _done;
        set
        {
            if (value && !_done)
            {
                AddDomainEvent(new ProductCreatedEvent(this));
            }

            _done = value;
        }
    }
}
