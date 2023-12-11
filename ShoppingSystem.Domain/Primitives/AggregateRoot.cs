using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSystem.Domain.Primitives
{
    public abstract class AggregateRoot<T> : BaseEntity
    {
        [Key]
        [Required]
        public T Id { get; protected set; }
        public int Version { get; protected set; }

        private bool _versionIncremented;
        private readonly List<IDomainEvent> _domainEvents = new();
        public IEnumerable<IDomainEvent> Events => _events;

        private readonly List<IDomainEvent> _events = new();


        protected void AddEvent(IDomainEvent @event)
        {
            if (!_events.Any() && !_versionIncremented)
            {
                Version++;
                _versionIncremented = true;
            }

            _events.Add(@event);
        }

        public void ClearEvents() => _events.Clear();

        protected void IncrementVersion()
        {
            if (_versionIncremented)
            {
                return;
            }

            Version++;
            _versionIncremented = true;
        }
    }
}
