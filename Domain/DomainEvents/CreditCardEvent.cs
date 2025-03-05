using Domain.Entities;

namespace Domain.DomainEvents;

public abstract class CreditCardEvent : DomainEvent
{
    public CreditCard CreditCard { get; }
    protected CreditCardEvent(CreditCard creditCard)
    {
        CreditCard = creditCard;
    }
}