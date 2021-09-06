using System;
using System.Diagnostics.CodeAnalysis;

namespace MartianRobots.Domain.Entities
{
    public class GameResult : Entity<Guid>
    {
        public GameResult([NotNull]Game game, [NotNull] Robot robot)
        {
            GameId = game.Id;
            InitialCoordinate = robot.Position;
            InitialOrientation = robot.Orientation;
        }

        protected GameResult() { }

        public string Instructions { get; set; }

        public Guid GameId { get; set; }

        public Game Game { get; set; }

        public Coordinate InitialCoordinate { get; set; }

        public Orientations InitialOrientation { get; set; }

        public Coordinate EndCoordinate { get; set; }

        public Orientations EndOrientation { get; set; }
        
        public bool HasFallen { get; set; }

        public override string ToString()
        {
            var resultEnd = HasFallen ? " LOST" : string.Empty;
            return $"{EndCoordinate} { EndOrientation.ToString()[0] }{ resultEnd }";
        }
    }
}
