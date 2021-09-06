using MartianRobots.Domain.Entities;

namespace MartianRobots.Domain.Commands
{
    public class FrontMoveCommand : IRobotCommand
    {
        private readonly int stepLength;

        public FrontMoveCommand(int stepLength = 1)
        {
            this.stepLength = stepLength;
        }

        public void Execute(Robot robot)
        {
            robot.Position = robot.Orientation switch
            {
                Orientations.North => new Coordinate(robot.Position.X, robot.Position.Y + stepLength),
                Orientations.South => new Coordinate(robot.Position.X, robot.Position.Y - stepLength),
                Orientations.West => new Coordinate(robot.Position.X - 1, robot.Position.Y),
                Orientations.East => new Coordinate(robot.Position.X + 1, robot.Position.Y),
                _ => robot.Position
            };
        }
    }
}
