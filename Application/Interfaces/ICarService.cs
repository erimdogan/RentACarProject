using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces;

public interface ICarService
{
    Task<CarDTO> GetCarByIdAsync(Guid carId);
    Task<IEnumerable<CarDTO>> GetAllCarsAsync();
    Task AddCarAsync(CarDTO carDTO);
    Task UpdateCarAsync(CarDTO carDTO);
    Task DeleteCarAsync(Guid carId);
}