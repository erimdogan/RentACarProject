using Application.DTO;
using Domain.Entities;

namespace Application.Interfaces;

public interface IBrandService
{
    Task<BrandDTO?> GetBrandByIdAsync(Guid brandId);
    Task<IEnumerable<BrandDTO>> GetAllBrandsAsync();
    Task AddBrandAsync(BrandDTO brandDTO);
    Task UpdateBrandAsync(BrandDTO brandDTO);
    Task DeleteBrandAsync(Guid brandId);
    Task<IEnumerable<CarDTO>> GetCarsByBrandIdAsync(Guid brandId);
}