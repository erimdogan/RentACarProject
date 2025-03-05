using AutoMapper;
using Application.DTO;
using Domain.Entities;


namespace Application;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Brand, BrandDTO>();
        CreateMap<Car, CarDTO>();
        CreateMap<Brand, BrandDTO>();
        CreateMap<Customer, CustomerDTO>();
        CreateMap<CreditCard, CreditCardDTO>();

        CreateMap<BrandDTO, Brand>();
        CreateMap<CarDTO, Car>();
        CreateMap<BrandDTO, Brand>();
        CreateMap<CustomerDTO, Customer>();
        CreateMap<CreditCardDTO, CreditCard>();
    }
}