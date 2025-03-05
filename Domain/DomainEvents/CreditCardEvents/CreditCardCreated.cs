using Domain.Entities;

namespace Domain.DomainEvents.CreditCardEvents;

public class CreditCardCreated:CreditCardEvent
{
    public CreditCardCreated(CreditCard creditCard) : base(creditCard)
    {
    }
}