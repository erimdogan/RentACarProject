using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces;

public interface ICreditCardService
{
    Task<IEnumerable<CreditCardDTO>> GetAllCreditCardsAsync();
    Task<CreditCardDTO> GetByCardIdAsync(Guid cardId);
    Task<IEnumerable<CreditCardDTO>> GetByCardUserAsync(string cardUser);
    Task<CreditCardDTO> GetByCardNumberAsync(string cardNumber);
    Task AddCreditCardAsync(CreditCardDTO creditCardDTO);
    Task UpdateCreditCardAsync(CreditCardDTO creditCardDTO);
    Task DeleteCreditCardAsync(Guid cardId);
}