using Domain.Entities;

namespace Domain.DomainEvents.BrandEvents;

public class BrandDeleted:BrandEvent
{
    public BrandDeleted(Brand brand) : base(brand)
    {
    }
}