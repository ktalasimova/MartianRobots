using MartianRobots.Domain.Entities;
using System;

namespace MartianRobots.Domain.Commands
{
    public class RobotCommandFactory
    {
        public IRobotCommand GetCommand(char commandName)
        {
            return (commandName) switch
            {
                'L' => new RotateCommand(RotateDirections.Left),
                'R' => new RotateCommand(RotateDirections.Right),
                'F' => new FrontMoveCommand(),
                _ => throw new InvalidOperationException($"Command {commandName} is not supported")
            };
        }
    }
}
