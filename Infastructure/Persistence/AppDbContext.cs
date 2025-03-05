using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext:DbContext,IAppDbContext
{
    public DbSet<Brand> Brands { get; set; }
    public DbSet<CreditCard> CreditCards { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Rental> Rentals { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // DeleteOnCascade(DEFAULT) -> related entities deleted when principal entity deleted.
        // Restrict -> If any related entites have been restrict the deleting principal entity.
        // SetNull -> principal entity deleted then foreign key in the depentenden entity is set null.


        modelBuilder.Entity<CreditCard>()
            .HasOne(c=>c.Customer)
            .WithMany(cd=>cd.CreditCards)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Rental>()
            .HasOne(r=>r.Customer)
            .WithMany(c => c.Rentals)
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Car)
            .WithMany(cr => cr.Rentals)
            .HasForeignKey(r => r.CarId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Car>()
            .HasOne(cr=>cr.Brand)
            .WithMany(b=>b._cars)
            .HasForeignKey(cr=>cr.BrandId)
            .OnDelete(DeleteBehavior.Restrict);


        var brandId1 = new Guid("11111111-1111-1111-1111-111111111111");
        var brandId2 = new Guid("22222222-2222-2222-2222-222222222222");

        modelBuilder.Entity<Brand>().HasData(
            new Brand(){BrandId = brandId1, BrandName = "Audi"},
            new Brand(){BrandId = brandId2, BrandName = "BMW"}
            );

        var carId1 = new Guid("33333333-3333-3333-3333-333333333333");
        var carId2 = new Guid("44444444-4444-4444-4444-444444444444");


        modelBuilder.Entity<Car>().HasData(
            new Car()
            {
                CarId = carId1,
                BrandId = brandId1,
                CarName = "A5 45 TFSI",
                ModelYear = 2024,
                DailyPrice = 25.00M,
                Description = "Good Family Sport Car"
            },
            new Car()
            {
                CarId = carId2,
                BrandId = brandId2,
                CarName = "320i",
                ModelYear = 2022,
                DailyPrice = 20.00M,
                Description = "Good sport car for young"
            }
            );


        var customerId1 = new Guid("55555555-5555-5555-5555-555555555555");
        var customerId2 = new Guid("66666666-6666-6666-6666-666666666666");

        modelBuilder.Entity<Customer>().HasData(
            new Customer()
            {
                CustomerId = customerId1,
                CustomerName ="Erim",
                CustomerEmail = "skjdfldskfj@gmail.com"
            },
            new Customer()
            {
                CustomerId = customerId2,
                CustomerName = "Mert",
                CustomerEmail = "akdjasdajkdsaj@gmail.com"
            }
            );

        var creditCardId1 = new Guid("77777777-7777-7777-7777-777777777777");
        var creditCardId2 = new Guid("88888888-8888-8888-8888-888888888888");
        var creditCardId3 = new Guid("99999999-9999-9999-9999-999999999999");

        modelBuilder.Entity<CreditCard>().HasData(
            new CreditCard()
            {
                CardId = creditCardId1,
                CardNumber = "1234123412341234",
                CardUser = "Erim",
                ValidDate = "12/25",
                Cvv = "123"
            },
            new CreditCard()
            {
                CardId = creditCardId2,
                CardNumber = "1111111111111111",
                CardUser = "Erim",
                ValidDate = "12/25",
                Cvv = "124"
            },
            new CreditCard()
            {
                CardId = creditCardId3,
                CardNumber = "4321432143214321",
                CardUser = "Mert",
                ValidDate = "11/25",
                Cvv = "321"
            }
            );

        var rentalId = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

        modelBuilder.Entity<Rental>().HasData(
            new Rental()
            {
                RentId = rentalId,
                CarId = carId1,
                CustomerId = customerId1,
                RentStartDateTime = new DateTime(2025, 3, 5),
                RentEndDateTime = new DateTime(2025, 3, 10),
                RentStatus = RentalStatus.Rented
            }
            );
    }
}