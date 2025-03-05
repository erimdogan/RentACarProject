using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public interface IAppDbContext
{
    DbSet<Brand> Brands { get; set; }
    DbSet<CreditCard> CreditCards { get; set; }
    DbSet<Customer> Customers { get; set; }
    DbSet<Car> Cars { get; set; }
    DbSet<Rental> Rentals { get; set; }
}