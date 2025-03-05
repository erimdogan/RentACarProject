namespace Domain.DomainEvents;

public interface IEventHandler<TEvent> where TEvent:DomainEvent
{
    void Handle(TEvent domainEvent);
}
