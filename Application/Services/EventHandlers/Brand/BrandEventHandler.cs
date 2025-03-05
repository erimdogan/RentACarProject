using Domain.DomainEvents;
using Domain.DomainEvents.BrandEvents;

namespace Application.Services.EventHandlers.Brand;

public class BrandEventHandler :
    IEventHandler<BrandCreated>,
    IEventHandler<BrandUpdated>,
    IEventHandler<BrandDeleted>
{
    private List<BrandCreated> _brandCreatedEvents = new();
    private List<BrandUpdated> _brandUpdatedEvents = new();
    private List<BrandDeleted> _brandDeletedEvents = new();

    public void Handle(BrandCreated domainEvent)
    {
        _brandCreatedEvents.Add(domainEvent);
        Console.WriteLine($"Brand Created: {domainEvent.Brand.BrandName}");
    }

    public void Handle(BrandUpdated domainEvent)
    {
        _brandUpdatedEvents.Add(domainEvent);
        Console.WriteLine($"Brand Updated: {domainEvent.Brand.BrandName}");
    }

    public void Handle(BrandDeleted domainEvent)
    {
        _brandDeletedEvents.Add(domainEvent);
        Console.WriteLine($"Brand Deleted: {domainEvent.Brand.BrandName}");
    }
}