//using System;
//using System.Collections;
//using System.Reflection;
//using Application.Services;
//using Domain;
//using Domain.Entities;
//using System.Collections.Generic;
//using Application.DTO;
//using Application.Interfaces;
//using Application.Services.EventHandlers.CreditCard;
//using Domain.DomainEvents;
//using Domain.Interfaces;
//using Infrastructure;
//using Infrastructure.Repositories;
//using Microsoft.Extensions.DependencyInjection;
//using Domain.DomainEvents.CreditCardEvents;

//class Program
//{
//    public static void Main()
//    {
        
//        var serviceProvider = new ServiceCollection()
//            .AddInjection() // Dependency Injection 
//            .BuildServiceProvider();

//        var brandService = serviceProvider.GetRequiredService<IBrandService>();
//        var carService = serviceProvider.GetRequiredService<ICarService>();
//        var creditCardService = serviceProvider.GetRequiredService<ICreditCardService>();


//        // CONTROL BRAND 

//        var newBrand = new BrandDTO() { BrandId = Guid.NewGuid(), BrandName = "Audi" };
//        brandService.Add(newBrand);

//        var newBrand_2 = new BrandDTO() { BrandId = Guid.NewGuid(), BrandName = "BMW" };
//        brandService.Add(newBrand_2);



//        // Get Brand By Id
//        Console.WriteLine("------CONTROL GET BY ID----------");
//        var brand = brandService.GetById(newBrand_2.BrandId);
//        Console.WriteLine($"Brand name: {brand.BrandName}, id: {brand.BrandId}"); 
        
//        // Get All Brands
//        Console.WriteLine("-----CONTROL GET ALL BRANDS------");
//        foreach (var brands in brandService.GetAllBrands())
//        {
//            Console.WriteLine($"{brands.BrandName}");
//        }

//        // Update Brand 
//        var updateBrand = new BrandDTO() { BrandId = newBrand_2.BrandId, BrandName = "Mercedes" };
//        brandService.Update(updateBrand);
//        var updatedBrand = brandService.GetById(newBrand_2.BrandId);

//        Console.WriteLine("-------- After updating -------------");
//        Console.WriteLine($"Brand name: {updatedBrand.BrandName}, id: {updatedBrand.BrandId}");

//        foreach (var brands in brandService.GetAllBrands())
//        {
//            Console.WriteLine($"{brands.BrandName}");
//        }

//        // Delete Brand 
//        Console.WriteLine("-------- After deleting -------------");
//        brandService.Delete(newBrand_2);
//        foreach (var brands in brandService.GetAllBrands())
//        {
//            Console.WriteLine($"{brands.BrandName}");
//        }

//        Console.WriteLine("----Brand Control Ends----");

//        //// CONTROL CAR

//        //var newCar = new Car() { CarId = 1, CarName = "A4", BrandId = 1, Description = "muk", DailyPrice = 5, ModelYear = 2022 };
//        //carService.Add(newCar);

//        //var newCar_2 = new Car() { CarId = 2, CarName = "X5", BrandId = 2, Description = "muk", DailyPrice = 5, ModelYear = 2022};
//        //carService.Add(newCar_2);

//        //// Get Car By Id
//        //var car = carService.GetById(2);
//        //Console.WriteLine($"Car name: {car.CarName}, id: {car.CarId}, brand id: {car.BrandId}");

//        //// Get All Cars
//        //foreach (var cars in carService.GetAllCars())
//        //{
//        //    Console.WriteLine($"{cars.CarName}");
//        //}

//        //// Update Car
//        //var updateCar = new Car() { CarId = 2, CarName = "X6", BrandId = 2, Description = "muk", DailyPrice = 5, ModelYear = 2022 };
//        //carService.Update(updateCar);
//        //var updatedCar = carService.GetById(2);

//        //Console.WriteLine("-------- After updating -------------");
//        //Console.WriteLine($"Car name: {updatedCar.CarName}, id: {updatedCar.CarId}, brand id: {updatedCar.BrandId}");

//        //foreach (var cars in carService.GetAllCars())
//        //{
//        //    Console.WriteLine($"{cars.CarName}");
//        //}

//        //// Delete Car
//        //Console.WriteLine("-------- After deleting -------------");
//        //carService.Delete(2);
//        //foreach (var cars in carService.GetAllCars())
//        //{
//        //    Console.WriteLine($"{cars.CarName}");
//        //}

//        //// CONTROL CREDIT CARD

//        //var creditCard1 = new CreditCardDTO()
//        //{
//        //    Id = Guid.NewGuid(), CardNumber = "123", CardUser = "erim", CustomerId = Guid.NewGuid(), Cvv = "111",
//        //    ValidDate = "02-2025"
//        //};
//        //creditCardService.Add(creditCard1);

//        //var creditCard2 = new CreditCardDTO()
//        //{
//        //    Id = Guid.NewGuid(), CardNumber = "113", CardUser = "erim", CustomerId = creditCard1.CustomerId,
//        //    Cvv = "191", ValidDate = "02-2026"
//        //};
//        //creditCardService.Add(creditCard2);

//        //var creditCard3 = new CreditCardDTO()
//        //{
//        //    Id = Guid.NewGuid(), CardNumber = "213", CardUser = "kerim", CustomerId = Guid.NewGuid(), Cvv = "291",
//        //    ValidDate = "02-2026"
//        //};
//        //creditCardService.Add(creditCard3);

//        //// Get by Id

//        //var card1 = creditCardService.GetByCardId(creditCard1.Id);
//        //if (card1 != null)
//        //{
//        //    Console.WriteLine($"CardId:{card1.CardId}" +
//        //                      $", CardNumber:{card1.CardNumber}" +
//        //                      $", CardUser:{card1.CardUser}" +
//        //                      $", CustomerId:{card1.CustomerId}" +
//        //                      $", Cvv:{card1.Cvv}" +
//        //                      $", ValidDates:{card1.ValidDate}");
//        //}
//        //else
//        //{
//        //    Console.WriteLine("Card not found.");
//        //}

//        //// Get by number
//        //Console.WriteLine("Get by cardnumber");
//        //var card1_num = creditCardService.GetByCardNumber(creditCard1.CardNumber);
//        //Console.WriteLine($"CardId:{card1.CardId}" +
//        //                  $", CardNumber:{card1.CardNumber}" +
//        //                  $", CardUser:{card1.CardUser}" +
//        //                  $", CustomerId:{card1.CustomerId}" +
//        //                  $", Cvv:{card1.Cvv}" +
//        //                  $", ValidDates:{card1.ValidDate}");


//        //// Get All 

//        //foreach (var cards in creditCardService.GetAll())
//        //{
//        //    Console.WriteLine($"Card Id:{cards.CardId}, User:{cards.CardUser}, Card Number: {cards.CardNumber}");
//        //}

//        //Console.WriteLine("Get By User");

//        //// Get By User

//        //foreach (var cards in creditCardService.GetByCardUser("erim"))
//        //{
//        //    Console.WriteLine($"Card Id:{cards.CardId}, User:{cards.CardUser}, Card Number: {cards.CardNumber}");
//        //}

//        //// Update 

//        //var updateCreditCard = new CreditCardDTO()
//        //{
//        //    Id = creditCard3.Id, CustomerId = creditCard3.CustomerId, CardNumber = "215", CardUser = "mehmet",
//        //    Cvv = "291", ValidDate = "02-2026"
//        //};
//        //creditCardService.Update(updateCreditCard);

//        //var nUpdatedCard3 = creditCardService.GetByCardId(updateCreditCard.Id);

//        //Console.WriteLine("----------- After Updated Card 3 ------------");
//        //Console.WriteLine(
//        //    $"Card Id: {nUpdatedCard3.CardId}, User: {nUpdatedCard3.CardUser}, Card Number: {nUpdatedCard3.CardNumber}");

//        //// Delete

//        //creditCardService.Delete(creditCard2);
//        //Console.WriteLine("----------- After Deleted Card 2 ------------");
//        //foreach (var cards in creditCardService.GetAll())
//        //{
//        //    Console.WriteLine($"Card Id:{cards.CardId}, User:{cards.CardUser}, Card Number: {cards.CardNumber}");
//        //}
//    }
//}