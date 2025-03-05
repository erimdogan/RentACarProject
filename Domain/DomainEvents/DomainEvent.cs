namespace Domain.DomainEvents;

public abstract class DomainEvent
{
    Guid Id { get; }
    DateTime occuredDateTime { get; }
}