using Domain.DomainEvents;
using Domain.DomainEvents.CreditCardEvents;

namespace Application.Services.EventHandlers.CreditCard;

public class CreditCardEventHandler:
    IEventHandler<CreditCardCreated>,
    IEventHandler<CreditCardDeleted>,
    IEventHandler<CreditCardUpdated>
{
    private readonly List<CreditCardCreated> _creditCardCreatedEvents = new();
    private readonly List<CreditCardDeleted> _creditCardDeletedEvents = new();
    private readonly List<CreditCardUpdated> _creditCardUpdatedEvents = new();

    public void Handle(CreditCardCreated domainEvent)
    {
        _creditCardCreatedEvents.Add(domainEvent);
    }

    public void Handle(CreditCardDeleted domainEvent)
    {
        _creditCardDeletedEvents.Add(domainEvent);
    }

    public void Handle(CreditCardUpdated domainEvent)
    {
        _creditCardUpdatedEvents.Add(domainEvent);
    }
}