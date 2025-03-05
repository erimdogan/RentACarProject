using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CarRepository:ICarRepository
{
    private readonly IAppDbContext _appDbContext;

    public CarRepository(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Car> GetCarByIdAsync(Guid carId)
    {
        return await _appDbContext.Cars.FirstOrDefaultAsync(c=>c.CarId==carId);
    }

    public async Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        return await _appDbContext.Cars.ToListAsync();
    }

    public async Task<Rental> GetRentalForCarAsync(Guid carId)
    {
        return await _appDbContext.Rentals.FirstOrDefaultAsync(r=>r.CarId==carId);
    }

    public async Task AddCarAsync(Car car)
    {
        await _appDbContext.Cars.AddAsync(car);
    }

    public async Task UpdateCarAsync(Car car)
    {
        var toUpdated = await _appDbContext.Cars.FirstOrDefaultAsync(c => c.CarId == car.CarId);
        if (toUpdated == null)
        {
            throw new ArgumentException($"Car with Id:{car.CarId} is not found");
        }
        _appDbContext.Cars.Entry(toUpdated).CurrentValues.SetValues(car);
    }

    public async Task DeleteCarAsync(Guid carId)
    {
        var toDeleted = await _appDbContext.Cars.FirstOrDefaultAsync(c => c.CarId == carId);
        if (toDeleted == null)
        {
            throw new ArgumentException($"Car with Id:{carId} is not found");
        }
        _appDbContext.Cars.Remove(toDeleted);
    }

    public async Task<bool> IsCarAvailableAsync(Guid carId)
    {
        bool carStatus = await _appDbContext.Rentals
            .AnyAsync(r => r.CarId == carId && r.RentStatus==RentalStatus.Available);
        return carStatus;
    }
}