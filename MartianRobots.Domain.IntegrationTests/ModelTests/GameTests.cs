using ApprovalTests;
using ApprovalTests.Reporters;
using MartianRobots.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MartianRobots.Domain.IntegrationTests.ModelTests
{
    [ApprovalTests.Namers.UseApprovalSubdirectory("Approvals")]
    public class GameTests
    {
        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void RunGame_WithWinningInstructions_ReturnsValidGameResult()
        {
            // Arrange
            var fakeSurface = new Surface(new Coordinate(4, 4));
            var initialCoordinate = new Coordinate(2, 2);
            var fakeRobots = new List<(Robot, string)>()
            {
                (new Robot(initialCoordinate, Orientations.North), "FLFLFLF"),
                (new Robot(initialCoordinate, Orientations.West), "RFRFRFFF"),
                (new Robot(initialCoordinate, Orientations.South), "FFLRLRLFR"),
                (new Robot(initialCoordinate, Orientations.East), "FLLFRRFLRLRLR")
            };

            var game = new Game(fakeSurface);

            // Act
            var results = fakeRobots.Select(x =>
            {
                (Robot robot, string instruction) = x;
                game.AddRobot(robot);
                var result = game.RunGame(instruction);
                return result.ToString();
            });

            // Assert
            Approvals.Verify(JsonConvert.SerializeObject(results, Formatting.Indented));
        }

        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void RunGame_WithLosingInstructions_ReturnsValidGameResult()
        {
            // Arrange
            var fakeSurface = new Surface(new Coordinate(4, 4));
            var initialCoordinate = new Coordinate(2, 2);
            var fakeRobots = new List<(Robot, string)>()
            {
                (new Robot(initialCoordinate, Orientations.North), "FFLFFF"),
                (new Robot(initialCoordinate, Orientations.West), "RFRFFRFFFF"),
                (new Robot(initialCoordinate, Orientations.South), "FFLRLRFR"),
                (new Robot(initialCoordinate, Orientations.East), "FLLFRRFLRLRLRFFFF")
            };

            var game = new Game(fakeSurface);

            // Act
            var results = fakeRobots.Select(x =>
            {
                (Robot robot, string instruction) = x;
                game.AddRobot(robot);
                var result = game.RunGame(instruction);
                return result.ToString();
            });

            // Assert
            Approvals.Verify(JsonConvert.SerializeObject(results, Formatting.Indented));
        }
    }
}
