namespace Domain.Interfaces;

public interface IUnitOfWork:IDisposable
{
    ICustomerRepository Customers { get; }
    IBrandRepository Brands { get; }
    ICarRepository Cars { get; }
    ICreditCardRepository CreditCards { get; }
    IRentalRepository Rental { get; }

    Task<int> SaveChangesAsync();
}