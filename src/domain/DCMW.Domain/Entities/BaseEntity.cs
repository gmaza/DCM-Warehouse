using System;

namespace DCMW.Domain
{
    public class BaseEntity
    {
        private readonly Guid _id;
        public Guid ID
        {
            get => _id;
            init => _id = (value != default(Guid) ? value : throw new ArgumentNullException(nameof(ID)));
        }

        public BaseEntity(Guid id)
        {
            _id = id;
        }
    }
}