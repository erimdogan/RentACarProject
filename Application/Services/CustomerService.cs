using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class CustomerService:ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public async Task<CustomerDTO?> GetCustomerByIdAsync(Guid customerId)
    {
        var toMapped = await _unitOfWork.Customers.GetCustomerByIdAsync(customerId);
        return  _mapper.Map<CustomerDTO>(toMapped); // instead manually map
    }

    public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
    {
        var toMapped = await _unitOfWork.Customers.GetAllCustomersAsync();
        return _mapper.Map<IEnumerable<CustomerDTO>>(toMapped);
    }

    public async Task<IEnumerable<CreditCardDTO>> GetCreditCardsAsync(Guid customerId)
    {
        var toMapped = await _unitOfWork.Customers.GetCreditCardsAsync(customerId);
        return _mapper.Map<IEnumerable<CreditCardDTO>>(toMapped);
    }

    public async Task<IEnumerable<RentalDTO>> GetRentalsAsync(Guid customerId)
    {
        var toMapped = await _unitOfWork.Customers.GetRentalsAsync(customerId);
        return _mapper.Map<IEnumerable<RentalDTO>>(toMapped);
    }

    public async Task AddCustomerAsync(CustomerDTO customerDTO)
    {
        var toAdded = _mapper.Map<Customer>(customerDTO);
        await _unitOfWork.Customers.AddCustomerAsync(toAdded);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateCustomerAsync(CustomerDTO customerDTO)
    {
        var toUpdated = await _unitOfWork.Customers.GetCustomerByIdAsync(customerDTO.CustomerId);
        _mapper.Map(customerDTO, toUpdated);
        await _unitOfWork.Customers.UpdateCustomerAsync(toUpdated);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(Guid customerId)
    {
        await _unitOfWork.Customers.DeleteCustomerAsync(customerId);
        await _unitOfWork.SaveChangesAsync();
    }
}