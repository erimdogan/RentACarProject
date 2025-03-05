using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces;

public interface ICustomerService
{
    Task<CustomerDTO?> GetCustomerByIdAsync(Guid customerId);
    Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync();
    Task<IEnumerable<CreditCardDTO>> GetCreditCardsAsync(Guid customerId);
    Task<IEnumerable<RentalDTO>> GetRentalsAsync(Guid customerId);
    Task AddCustomerAsync(CustomerDTO customerDTO);
    Task UpdateCustomerAsync(CustomerDTO customerDTO);
    Task DeleteCustomerAsync(Guid customerId);
}