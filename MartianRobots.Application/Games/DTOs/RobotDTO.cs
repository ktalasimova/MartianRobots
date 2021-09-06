using MartianRobots.Domain.Entities;

namespace MartianRobots.Application.Games.DTOs
{
    public class RobotDTO
    {
        public Coordinate Position { get; set; }

        public Orientations Orientation { get; set; }

        public string Instructions { get; set; }
    }
}
