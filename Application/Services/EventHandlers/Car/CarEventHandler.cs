using Domain.DomainEvents.CarEvents;

namespace Domain.DomainEvents.Car;

public class CarEventHandler:
    IEventHandler<CarCreated>,
    IEventHandler<CarUpdated>,
    IEventHandler<CarDeleted>
{
    private readonly List<CarCreated> _carCreatedEvents = new();
    private readonly List<CarUpdated> _carUpdatedEvents = new();
    private readonly List<CarDeleted> _carDeletedEvents = new();

    public void Handle(CarCreated domainEvent)
    {
        _carCreatedEvents.Add(domainEvent);
        Console.WriteLine($"New Car Added. Id: {domainEvent.Car.CarId}\n Car Name: {domainEvent.Car.CarName}");
    }

    public void Handle(CarUpdated domainEvent)
    {
        _carUpdatedEvents.Add(domainEvent);
        Console.WriteLine($"Updated Car. Updated Car Id: {domainEvent.Car.CarId}");
    }

    public void Handle(CarDeleted domainEvent)
    {
        _carDeletedEvents.Add(domainEvent);
        Console.WriteLine($"Car Deleted");
    }
}