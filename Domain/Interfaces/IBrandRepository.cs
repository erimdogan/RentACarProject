    using Domain.Entities;

namespace Domain.Interfaces;

public interface IBrandRepository
{
    Task<Brand> GetByIdAsync(Guid brandId);
    Task<IEnumerable<Brand>> GetAllBrandsAsync();
    Task<IEnumerable<Car>> GetCarsByBrandIdAsync(Guid brandId);
    Task AddBrandAsync(Brand brand);
    Task UpdateBrandAsync(Brand brand);
    Task DeleteBrandAsync(Guid brandId);
}