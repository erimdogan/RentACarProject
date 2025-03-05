using Domain.Entities;

namespace Domain.DomainEvents;

public abstract class BrandEvent:DomainEvent
{
    public Brand Brand { get; }

    protected BrandEvent(Brand brand)
    {
        Brand = brand;
    }
}