using Domain.Entities;

namespace Domain.DomainEvents.CarEvents;

public class CarCreated:CarEvent
{
    public CarCreated(Car car) : base(car)
    {
    }
}