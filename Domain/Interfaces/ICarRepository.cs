using Domain.Entities;

namespace Domain.Interfaces;

public interface ICarRepository
{
    Task<Car> GetCarByIdAsync(Guid carId);
    Task<IEnumerable<Car>> GetAllCarsAsync();
    Task<Rental> GetRentalForCarAsync(Guid carId);
    Task AddCarAsync(Car car);
    Task UpdateCarAsync(Car car);
    Task DeleteCarAsync(Guid carId);
    Task<bool> IsCarAvailableAsync(Guid carId);
}