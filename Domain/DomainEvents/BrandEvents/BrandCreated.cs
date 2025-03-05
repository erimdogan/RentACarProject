using Domain.Entities;

namespace Domain.DomainEvents.BrandEvents;

public class BrandCreated:BrandEvent
{
    public BrandCreated(Brand brand) : base(brand)
    {
    }
}