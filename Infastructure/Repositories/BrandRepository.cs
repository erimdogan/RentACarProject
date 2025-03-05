using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Persistence;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BrandRepository:IBrandRepository
{
    private readonly IAppDbContext _appDbContext;

    //private readonly List<Brand> _brands = new()
    //{
    //    new Brand(){BrandId = Guid.Parse("91027256-21cf-4ca3-9fcf-a73fedcfd642"), BrandName = "a"},
    //    new Brand(){BrandId = Guid.NewGuid(), BrandName = "b"}
    //};

    public BrandRepository(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Brand> GetByIdAsync(Guid brandId)
    {
        return await _appDbContext.Brands.FirstOrDefaultAsync(b=>b.BrandId==brandId);
    }

    public async Task<IEnumerable<Brand>> GetAllBrandsAsync()
    {
        return await _appDbContext.Brands.ToListAsync();
    }

    public async Task<IEnumerable<Car>> GetCarsByBrandIdAsync(Guid brandId)
    {
        return await _appDbContext.Cars.Where(c => c.BrandId == brandId).ToListAsync();
    }

    public async Task AddBrandAsync(Brand brand)
    {
        await _appDbContext.Brands.AddAsync(brand);
    }

    public async Task UpdateBrandAsync(Brand brand)
    {
        var toUpdated = await _appDbContext.
            Brands
            .FirstOrDefaultAsync(b => b.BrandId == brand.BrandId); // selecting what brand will updated
        if (toUpdated == null)
        {
            throw new ArgumentException($"Brand with id {brand.BrandId} is not found");
        }
        _appDbContext.Brands.Entry(toUpdated).CurrentValues.SetValues(brand);
    }

    public async Task DeleteBrandAsync(Guid brandId)
    {
       var toDeleted = await _appDbContext
           .Brands
           .FirstOrDefaultAsync(b=>b.BrandId==brandId);
       if (toDeleted == null)
       {
           throw new ArgumentException($"Brand with id {brandId} is not found");
       }

       _appDbContext.Brands.Remove(toDeleted);
    }
}