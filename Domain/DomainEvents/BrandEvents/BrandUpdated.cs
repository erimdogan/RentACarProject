using Domain.Entities;

namespace Domain.DomainEvents.BrandEvents;

public class BrandUpdated:BrandEvent
{
    public BrandUpdated(Brand brand) : base(brand)
    {
    }
}