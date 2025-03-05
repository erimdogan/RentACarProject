using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure.Persistence;

public class UnitOfWork:IUnitOfWork
{
    private readonly AppDbContext _appDbContext;

    private readonly ICustomerRepository _customerRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly ICarRepository _carRepository;
    private readonly ICreditCardRepository _creditCardRepository;
    private readonly IRentalRepository _rentalRepository;

    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public ICustomerRepository Customers => _customerRepository ?? new CustomerRepository(_appDbContext);
    public IBrandRepository Brands => _brandRepository ?? new BrandRepository(_appDbContext);
    public ICarRepository Cars => _carRepository ?? new CarRepository(_appDbContext);
    public ICreditCardRepository CreditCards => _creditCardRepository ?? new CreditCardRepository(_appDbContext);
    public IRentalRepository Rental => _rentalRepository ?? new RentalRepository(_appDbContext);

    public async Task<int> SaveChangesAsync()
    {
        return await _appDbContext.SaveChangesAsync();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _appDbContext?.Dispose();
            }
            _disposed = true;
        }
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}