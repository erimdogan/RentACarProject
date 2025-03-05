using Domain.Entities;

namespace Domain.DomainEvents.CreditCardEvents;

public class CreditCardUpdated:CreditCardEvent
{
    public CreditCardUpdated(CreditCard creditCard) : base(creditCard)
    {
    }
}