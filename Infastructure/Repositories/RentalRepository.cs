using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RentalRepository:IRentalRepository
{
    private readonly IAppDbContext _appDbContext;

    public RentalRepository(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
    {
        return await _appDbContext.Rentals.ToListAsync();
    }

    public async Task<IEnumerable<Rental>> GetAvailableRentalsAsync()
    {
        return await _appDbContext.Rentals
            .Where(r=>r.RentStatus==RentalStatus.Available).ToListAsync();
    }

    public async Task<IEnumerable<Rental>> GetRentedRentalsAsync()
    {
        return await _appDbContext.Rentals
            .Where(r => r.RentStatus == RentalStatus.Rented).ToListAsync();
    }

    public async Task<Rental> GetByRentalIdAsync(Guid rentalId)
    {
        return await _appDbContext.Rentals
            .FirstOrDefaultAsync(r=>r.RentId == rentalId);
    }

    public async Task AddRentalAsync(Rental rental)
    {
        await _appDbContext.Rentals.AddAsync(rental);
        Console.WriteLine($"Rental Added {rental.RentId}");
    }

    public async Task UpdateRentalAsync(Rental rental)
    {
        var toUpdated = await _appDbContext.Rentals
            .FirstOrDefaultAsync(r => r.RentId == rental.RentId);
        if (toUpdated == null)
        {
            throw new ArgumentException($"Rental Id:{rental.RentId} is not found");
        }
        _appDbContext.Rentals.Entry(toUpdated).CurrentValues.SetValues(rental);
    }

    public async Task DeleteRentalAsync(Guid rentalId)
    {
        var toDeleted = await _appDbContext.Rentals
            .FirstOrDefaultAsync(r => r.RentId == rentalId);
        if (toDeleted == null)
        {
            throw new ArgumentException($"Rental Id:{rentalId} is not found");
        }
        _appDbContext.Rentals.Remove(toDeleted);
    }
}