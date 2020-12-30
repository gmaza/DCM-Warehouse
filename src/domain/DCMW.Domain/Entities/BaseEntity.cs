using DCMW.Domain.Abstractions.DomainEvents;
using System;
using System.Collections.Generic;

namespace DCMW.Domain
{
    public abstract class BaseEntity
    {
        private Guid _id;
        public Guid ID
        {
            get => _id;
        }

        protected BaseEntity(Guid id)
        {
            _id = id;
        }

        protected BaseEntity()
        {
        }

        public List<IDomainEvent> Events { get; } = new List<IDomainEvent>();
    }
}