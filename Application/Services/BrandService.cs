using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.DomainEvents;
using Domain.DomainEvents.BrandEvents;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class BrandService:IBrandService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IEventHandler<BrandCreated> _brandCreated;
    private readonly IEventHandler<BrandDeleted> _brandDeleted;
    private readonly IEventHandler<BrandUpdated> _brandUpdated;

    public BrandService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IEventHandler<BrandCreated> brandCreated,
        IEventHandler<BrandDeleted> brandDeleted,
        IEventHandler<BrandUpdated> brandUpdated)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _brandCreated = brandCreated;
        _brandDeleted = brandDeleted;
        _brandUpdated = brandUpdated;
    }

    public async Task<BrandDTO?> GetBrandByIdAsync(Guid brandId)
    {
        var brand = await _unitOfWork.Brands.GetByIdAsync(brandId);
        return _mapper.Map<BrandDTO>(brand);
    }

    public async Task<IEnumerable<BrandDTO>> GetAllBrandsAsync()
    {
        var brands = await _unitOfWork.Brands.GetAllBrandsAsync();
        return _mapper.Map<IEnumerable<BrandDTO>>(brands);
    }

    public async Task<IEnumerable<CarDTO>> GetCarsByBrandIdAsync(Guid brandId)
    {
        var cars = await _unitOfWork.Brands.GetCarsByBrandIdAsync(brandId);
        return _mapper.Map<IEnumerable<CarDTO>>(cars);
    }

    public async Task AddBrandAsync(BrandDTO brandDTO)
    { 
        //var brand = new Brand()
        //{
        //    BrandId = Guid.NewGuid(),
        //    BrandName = brandDTO.BrandName
        //};
        //_brandRepository.Add(brand);
        //_unitOfWork.commit();
        var brand = _mapper.Map<Brand>(brandDTO);
        await _unitOfWork.Brands.AddBrandAsync(brand);
        await _unitOfWork.SaveChangesAsync();

        var createEvent = new BrandCreated(brand);
        _brandCreated.Handle(createEvent);
    }

    public async Task UpdateBrandAsync(BrandDTO brandDTO)
    {
        //var toUpdated = _brandRepository.GetById(brandId);
        //if (toUpdated != null)
        //{
        //    toUpdated.BrandName=brandDTO.BrandName;

        //    _brandRepository.Update(toUpdated);
        //    _unitOfWork.commit();

        var toUpdated = await _unitOfWork.Brands.GetByIdAsync(brandDTO.BrandId);
        _mapper.Map(brandDTO, toUpdated);
        await _unitOfWork.Brands.UpdateBrandAsync(toUpdated);
        await _unitOfWork.SaveChangesAsync();

        var updateEvent = new BrandUpdated(toUpdated);
        _brandUpdated.Handle(updateEvent);
    }

    public async Task DeleteBrandAsync(Guid brandId)
    {
        //var toDeleted = _brandRepository.GetById(brandId);
        //if (toDeleted != null)
        //{
        //    _brandRepository.Delete(toDeleted);
        //    _unitOfWork.commit();

        await _unitOfWork.Brands.DeleteBrandAsync(brandId);
        await _unitOfWork.SaveChangesAsync();

    }
}