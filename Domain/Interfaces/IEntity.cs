using Domain.DomainEvents;

namespace Domain.Interfaces;

public abstract class IEntity
{
    private readonly List<DomainEvent> _domainEvent = new();
}