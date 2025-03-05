using Application.Interfaces;
using Application.Services;
using Application.Services.EventHandlers.Brand;
using Application.Services.EventHandlers.CreditCard;
using Domain.DomainEvents;
using Domain.DomainEvents.BrandEvents;
using Domain.DomainEvents.Car;
using Domain.DomainEvents.CarEvents;
using Domain.DomainEvents.CreditCardEvents;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInjection(this IServiceCollection services)
    {
        services
            .AddScoped<IBrandRepository, BrandRepository>()
            .AddScoped<IBrandService, BrandService>()
            .AddScoped<ICarRepository, CarRepository>()
            .AddScoped<ICarService, CarService>()
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<ICustomerService, CustomerService>()
            .AddScoped<ICreditCardService, CreditCardService>()
            .AddScoped<ICreditCardRepository, CreditCardRepository>()
            .AddScoped<IRentalService, RentalService>()
            .AddScoped<IRentalRepository, RentalRepository>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

        services.AddScoped<CreditCardEventHandler>();
        services.AddScoped<BrandEventHandler>();
        services.AddScoped<CarEventHandler>();

        services.AddScoped<IEventHandler<CreditCardCreated>>(provider => provider.GetRequiredService<CreditCardEventHandler>());
        services.AddScoped<IEventHandler<CreditCardUpdated>>(provider => provider.GetRequiredService<CreditCardEventHandler>());
        services.AddScoped<IEventHandler<CreditCardDeleted>>(provider => provider.GetRequiredService<CreditCardEventHandler>());

        services.AddScoped<IEventHandler<BrandCreated>>(provider => provider.GetRequiredService<BrandEventHandler>());
        services.AddScoped<IEventHandler<BrandUpdated>>(provider => provider.GetRequiredService<BrandEventHandler>());
        services.AddScoped<IEventHandler<BrandDeleted>>(provider => provider.GetRequiredService<BrandEventHandler>());

        services.AddScoped<IEventHandler<CarCreated>>(provider => provider.GetRequiredService<CarEventHandler>());
        services.AddScoped<IEventHandler<CarUpdated>>(provider => provider.GetRequiredService<CarEventHandler>());
        services.AddScoped<IEventHandler<CarDeleted>>(provider => provider.GetRequiredService<CarEventHandler>());
        return services;
    }
}