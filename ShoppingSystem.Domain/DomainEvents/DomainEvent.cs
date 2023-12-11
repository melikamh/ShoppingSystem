using ShoppingSystem.Domain.Primitives;

namespace ShoppingSystem.Domain.DomainEvents
{
    public abstract record DomainEvent (int Id) : IDomainEvent;
}
