using MartianRobots.Domain.Entities;
using System;
using System.Linq;

namespace MartianRobots.Domain.Commands
{
    public class RotateCommand : IRobotCommand
    {
        public readonly RotateDirections RotateDirection;

        public RotateCommand(RotateDirections rotateDirection)
        {
            this.RotateDirection = rotateDirection;
        }

        public void Execute(Robot robot)
        {
            var orientationValues = Enum.GetValues<Orientations>().ToList();
            var increment = RotateDirection == RotateDirections.Left ? -1 : 1;

            var robotDirectionIndex = orientationValues.IndexOf(robot.Orientation);
            var indexAfterRotate = (robotDirectionIndex + increment) % orientationValues.Count;
            robot.Orientation = orientationValues[indexAfterRotate >= 0 ? indexAfterRotate : orientationValues.Count - 1];
        }
    }
}
