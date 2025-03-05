using Domain.Entities;

namespace Domain.DomainEvents.CarEvents;

public class CarUpdated:CarEvent
{
    public CarUpdated(Car car) : base(car)
    {
    }
}