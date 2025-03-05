using Domain.Entities;

namespace Domain.Interfaces;

public interface IRentalRepository
{
    Task<IEnumerable<Rental>> GetAllRentalsAsync();
    Task<IEnumerable<Rental>> GetAvailableRentalsAsync();
    Task<IEnumerable<Rental>> GetRentedRentalsAsync();
    Task<Rental> GetByRentalIdAsync(Guid rentalId);
    Task AddRentalAsync(Rental rental);
    Task UpdateRentalAsync(Rental rental);
    Task DeleteRentalAsync(Guid rentalId);
}