using System;
using System.Diagnostics.CodeAnalysis;

namespace MartianRobots.Domain.Entities
{
    public class Robot : Entity<Guid>
    {
        public Coordinate Position { get; set; }

        public Orientations Orientation { get; set; }

        public GameResult GameResult { get; set; }


        public Robot([NotNull] Coordinate position, Orientations orientation)
        {
            Position = position;
            Orientation = orientation;
        }

        protected Robot() { }

    }
}
