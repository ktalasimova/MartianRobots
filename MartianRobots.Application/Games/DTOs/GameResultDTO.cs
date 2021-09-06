using MartianRobots.Domain.Entities;

namespace MartianRobots.Application.Games.DTOs
{
    public class GameResultDTO
    {
        public Coordinate InitialCoordinate { get; set; }

        public Orientations InitialOrientation { get; set; }

        public string Instructions { get; set; }

        public Coordinate EndCoordinate { get; set; }

        public Orientations EndOrientation { get; set; }

        public bool Lost { get; set; }
    }
}
