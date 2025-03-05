using Domain.Entities;

namespace Domain.Interfaces;

public interface ICreditCardRepository
{
    Task<IEnumerable<CreditCard>> GetAllCreditCardsAsync();
    Task<CreditCard> GetByCardIdAsync(Guid cardId);
    Task<IEnumerable<CreditCard>> GetByCardUserAsync(string cardUser);
    Task<CreditCard> GetByCardNumberAsync(string cardNumber);
    Task AddCreditCardAsync(CreditCard creditCard);
    Task UpdateCreditCardAsync(CreditCard creditCard);
    Task DeleteCreditCardAsync(Guid cardId);
}