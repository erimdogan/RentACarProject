using Domain.Entities;

namespace Domain.DomainEvents.CarEvents;

public class CarDeleted:CarEvent
{
    public CarDeleted(Car car) : base(car)
    {
    }
}