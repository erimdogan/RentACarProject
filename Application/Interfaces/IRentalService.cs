using Application.DTO;

namespace Application.Interfaces;

public interface IRentalService
{
    Task<IEnumerable<RentalDTO>> GetAllRentalsAsync();
    Task<IEnumerable<RentalDTO>> GetAvailableRentalsAsync();
    Task<IEnumerable<RentalDTO>> GetRentedRentalsAsync();
    Task<RentalDTO> GetRentalForCarAsync(Guid carId);
    Task<RentalDTO> GetByRentalIdAsync(Guid rentalId);
    Task EndRentalAsync(RentalDTO rentalDTO);
    Task AddRentalAsync(RentalDTO rentalDTO);
    Task UpdateRentalAsync(RentalDTO rentalDTO);
    Task DeleteRentalAsync(Guid rentId);
}