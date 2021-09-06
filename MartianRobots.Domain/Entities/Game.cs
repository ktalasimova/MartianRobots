using MartianRobots.Domain.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace MartianRobots.Domain.Entities
{
    public class Game : Entity<Guid>
    {
        private readonly Surface _surface;
        private readonly Queue<Robot> _robotsQueue = new();

        private readonly RobotCommandFactory _robotCommandFactory;

        [NotMapped]
        public ICollection<Robot> Robots { get; private set;  } = new List<Robot>();

        public int LostRobots { get; private set; }

        public int WonRobots { get; private set; }

        public double ExploredSurfaceRate { get; private set; }

        public ICollection<GameResult> GameResults { get; set; } = new List<GameResult>();

        public Game([NotNull]Surface surface)
        {
            this._surface = surface;
            _robotCommandFactory = new RobotCommandFactory();
        }

        protected Game() { }

        public void AddRobot(Robot robot)
        {
            Robots.Add(robot);
            _robotsQueue.Enqueue(robot);
        }

        public GameResult RunGame(string instructions)
        {
            var robot = _robotsQueue.Dequeue();
            var result = new GameResult(this, robot)
            {
                Instructions = instructions
            };

            foreach(var commandName in instructions)
            {
                _surface.Explore(robot.Position);

                var command = _robotCommandFactory.GetCommand(commandName);

                command.Execute(robot);

                if (_surface.OutOfTheBound(robot.Position))
                {
                    result.HasFallen = true;
                    break;
                }

                result.EndOrientation = robot.Orientation;
                result.EndCoordinate = robot.Position;
            }

            SaveGameResult(result);
            return result;
        }

        private void SaveGameResult(GameResult result)
        {
            GameResults.Add(result);

            if (result.HasFallen)
            {
                ++LostRobots;
            }
            else
            {
                ++WonRobots;
            }

            ExploredSurfaceRate = _surface.GetExploredRate();
        }
    }
}
