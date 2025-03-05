using Application.DTO;
using Application.Interfaces;
using Application.Services.EventHandlers.CreditCard;
using AutoMapper;
using Domain.DomainEvents;
using Domain.DomainEvents.CreditCardEvents;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class CreditCardService:ICreditCardService
{
    private readonly ICreditCardRepository _creditCardRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventHandler<CreditCardCreated> _createdEventHandler;
    private readonly IEventHandler<CreditCardUpdated> _updatedEventHandler;
    private readonly IEventHandler<CreditCardDeleted> _deletedEventHandler;

    public CreditCardService(
        ICreditCardRepository creditCardRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IEventHandler<CreditCardCreated> createdEventHandler,
        IEventHandler<CreditCardUpdated> updatedEventHandler,
        IEventHandler<CreditCardDeleted> deletedEventHandler)
    {
        _creditCardRepository = creditCardRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _createdEventHandler = createdEventHandler;
        _updatedEventHandler = updatedEventHandler;
        _deletedEventHandler = deletedEventHandler;
    }

    public async Task<IEnumerable<CreditCardDTO>> GetAllCreditCardsAsync()
    {
        var creditCards = await _unitOfWork.CreditCards.GetAllCreditCardsAsync();
        return _mapper.Map<IEnumerable<CreditCardDTO>>(creditCards);
    }

    public async Task<CreditCardDTO> GetByCardIdAsync(Guid cardId)
    {
        var creditCard = await _unitOfWork.CreditCards.GetByCardIdAsync(cardId);
        return _mapper.Map<CreditCardDTO>(creditCard);
    }

    public async Task<IEnumerable<CreditCardDTO>> GetByCardUserAsync(string cardUser)
    {
        var creditCards = await _unitOfWork.CreditCards.GetByCardUserAsync(cardUser);
        return _mapper.Map<IEnumerable<CreditCardDTO>>(creditCards);
    }

    public async Task<CreditCardDTO> GetByCardNumberAsync(string cardNumber)
    {
        var creditCard = await _unitOfWork.CreditCards.GetByCardNumberAsync(cardNumber);
        return _mapper.Map<CreditCardDTO>(creditCard);
    }

    public async Task AddCreditCardAsync(CreditCardDTO creditCardDto)
    {
        var creditCard = _mapper.Map<CreditCard>(creditCardDto);
        await _unitOfWork.CreditCards.AddCreditCardAsync(creditCard);
        await _unitOfWork.SaveChangesAsync();

        var createdEvent = new CreditCardCreated(creditCard);
        _createdEventHandler.Handle(createdEvent);
    }

    public async Task UpdateCreditCardAsync(CreditCardDTO creditCardDTO)
    {
        //var existingCreditCard = _creditCardRepository.GetByCardId(creditCardId); //guncellenecek karti buluyoruz
        //if (existingCreditCard != null)
        //{   // ilgili karti guncelliyoruz

        //    existingCreditCard.CardUser=creditCardDTO.CardUser;
        //    existingCreditCard.CardNumber=creditCardDTO.CardNumber;
        //    existingCreditCard.Cvv =creditCardDTO.Cvv;
        //    existingCreditCard.ValidDate=creditCardDTO.ValidDate;
            
        //    _creditCardRepository.Update(existingCreditCard);
        //    _unitOfWork.commit();

        //    var updatedEvent = new CreditCardUpdated(existingCreditCard);
        //    _updatedEventHandler.Handle(updatedEvent);
        //}
        //else
        //{
        //    Console.WriteLine("Card is null");
        //}

        var toUpdated = await _unitOfWork.CreditCards.GetByCardIdAsync(creditCardDTO.CardId);
        await _unitOfWork.CreditCards.UpdateCreditCardAsync(toUpdated);
        await _unitOfWork.SaveChangesAsync();

    }

    public async Task DeleteCreditCardAsync(Guid creditCardId)
    {
        await _unitOfWork.CreditCards.DeleteCreditCardAsync(creditCardId);
        await _unitOfWork.SaveChangesAsync();
    }
}