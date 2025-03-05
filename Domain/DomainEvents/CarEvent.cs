using Domain.Entities;

namespace Domain.DomainEvents;

public abstract class CarEvent:DomainEvent
{
    public Car Car { get; }

    protected CarEvent(Car car)
    {
        Car = car;
    }
}