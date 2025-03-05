using Domain.Entities;

namespace Domain.Interfaces;

public interface ICustomerRepository
{
    Task<Customer?> GetCustomerByIdAsync(Guid customerId);
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<IEnumerable<CreditCard>> GetCreditCardsAsync(Guid customerId);
    Task<IEnumerable<Rental>> GetRentalsAsync(Guid customerId);
    Task AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(Guid customerId);
}