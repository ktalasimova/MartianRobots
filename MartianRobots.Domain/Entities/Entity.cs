using System;

namespace MartianRobots.Domain.Entities
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }

        public DateTimeOffset CreatedDateTime { get; set; }
    }
}
