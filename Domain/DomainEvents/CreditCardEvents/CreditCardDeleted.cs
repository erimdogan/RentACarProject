using Domain.Entities;

namespace Domain.DomainEvents.CreditCardEvents;

public class CreditCardDeleted:CreditCardEvent
{
    public CreditCardDeleted(CreditCard creditCard) : base(creditCard)
    {
    }
}