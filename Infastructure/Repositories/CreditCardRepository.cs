using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CreditCardRepository:ICreditCardRepository
{
    private readonly IAppDbContext _appDbContext;

    public CreditCardRepository(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }


    public async Task<IEnumerable<CreditCard>> GetAllCreditCardsAsync()
    {
        return await _appDbContext.CreditCards.ToListAsync();
    }

    public async Task<CreditCard> GetByCardIdAsync(Guid cardId)
    {
        return await _appDbContext.CreditCards
            .FirstOrDefaultAsync(cd => cd.CardId == cardId);
    }

    public async Task<IEnumerable<CreditCard>> GetByCardUserAsync(string cardUser)
    {
        return await _appDbContext.CreditCards
            .Where(cd=>cd.CardUser==cardUser)
            .ToListAsync();
    }

    public async Task<CreditCard> GetByCardNumberAsync(string cardNumber)
    {
        return await _appDbContext.CreditCards
            .FirstOrDefaultAsync(cd => cd.CardNumber == cardNumber);
    }

    public async Task AddCreditCardAsync(CreditCard creditCard)
    {
         await _appDbContext.CreditCards.AddAsync(creditCard);
    }

    public async Task UpdateCreditCardAsync(CreditCard creditCard)
    {
        var toUpdated = await _appDbContext.CreditCards.FirstOrDefaultAsync(cd => cd.CardId == creditCard.CardId);
        if (toUpdated == null)
        {
            throw new ArgumentException($"Credit Card with Id:{creditCard.CardId} is not found.");
        }

        _appDbContext.CreditCards.Entry(toUpdated).CurrentValues.SetValues(creditCard);
    }

    public async Task DeleteCreditCardAsync(Guid cardId)
    {
        var toRemoved = await _appDbContext.CreditCards
            .FirstOrDefaultAsync(cd => cd.CardId == cardId);
        if (toRemoved == null)
        {
            throw new ArgumentException($"Credit Card with Id {cardId} is not found");
        }
        _appDbContext.CreditCards.Remove(toRemoved);
    }
}