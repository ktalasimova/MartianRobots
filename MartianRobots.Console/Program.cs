using MartianRobots.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MartianRobots.Console
{
    class Program
    {
        private const string LOST = "LOST";
        private const string SEPARATOR = " ";

        static void Main(string[] args)
        {
            try
            {
                using var sr = new StreamReader(System.Console.OpenStandardInput(), System.Console.InputEncoding);
                var input = sr.ReadToEnd();
                var lines = new Queue<string>(input.Split(Environment.NewLine).Where(x => !string.IsNullOrEmpty(x)));

                var surfaceCoordinates = lines.Dequeue()
                    .Split(SEPARATOR)
                    .Select(x => int.Parse(x))
                    .ToList();
                var surface = new Surface(GetCoordinate(surfaceCoordinates));
                var game = new Game(surface);

                while (lines.Any())
                {
                    var robotCoordinates = lines.Dequeue().Split(SEPARATOR);
                    var robotPosition = new Coordinate(int.Parse(robotCoordinates[0]), int.Parse(robotCoordinates[1]));
                    var robotOrientation = GetOrientation(robotCoordinates[2][0]);
                    var robot = new Robot(robotPosition, robotOrientation);

                    game.AddRobot(robot);

                    var instructions = lines.Dequeue();

                    var gameResult = game.RunGame(instructions);
                    System.Console.WriteLine($"{ gameResult }");

                }
            }
            catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        private static Coordinate GetCoordinate(List<int> coordinates)
        {
            return new Coordinate(coordinates[0], coordinates[1]);
        }

        private static Orientations GetOrientation(char orientation)
        {
            return orientation switch
            {
                'N' => Orientations.North,
                'S' => Orientations.South,
                'E' => Orientations.East,
                'W' => Orientations.West,
            };
        }
    }
}
