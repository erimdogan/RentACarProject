using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CustomerRepository:ICustomerRepository
{
    private readonly IAppDbContext _appDbContext;

    public CustomerRepository(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Customer?> GetCustomerByIdAsync(Guid customerId)
    {
        return await _appDbContext.Customers.FirstOrDefaultAsync(c=>c.CustomerId==customerId);
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _appDbContext.Customers.ToListAsync();
    }

    public async Task<IEnumerable<CreditCard>> GetCreditCardsAsync(Guid customerId)
    {
        return await _appDbContext.CreditCards.Where(cd=>cd.CustomerId==customerId).ToListAsync();
    }

    public async Task<IEnumerable<Rental>> GetRentalsAsync(Guid customerId)
    {
        return await _appDbContext.Rentals.Where(r=>r.CustomerId==customerId).ToListAsync();
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        await _appDbContext.Customers.AddAsync(customer);
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        var toUpdated = await _appDbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == customer.CustomerId);
        if (toUpdated == null)
        {
            throw new ArgumentException($"Customer with Id{customer.CustomerId} is not found");
        }
        
        _appDbContext.Customers.Entry(toUpdated).CurrentValues.SetValues(customer);
    }

    public async Task DeleteCustomerAsync(Guid customerId)
    {
        var toDeleted = await _appDbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
        if (toDeleted == null)
        {
            throw new ArgumentException($"Customer with Id{customerId} is not found");
        }

        _appDbContext.Customers.Remove(toDeleted);
    }
}