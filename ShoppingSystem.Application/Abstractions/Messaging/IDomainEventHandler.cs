using ShoppingSystem.Domain.Primitives;
using MediatR;


namespace ShoppingSystem.Application.Abstractions.Messaging
{
    public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
      where TEvent : IDomainEvent
    {
    }

}
