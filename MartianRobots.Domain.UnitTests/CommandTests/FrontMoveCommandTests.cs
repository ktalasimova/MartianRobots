using MartianRobots.Domain.Commands;
using MartianRobots.Domain.Entities;
using Xunit;

namespace MartianRobots.Domain.UnitTests.CommandTests
{
    public class FrontMoveCommandTests
    {
        [Theory]
        [InlineData(Orientations.East, 2, 1)]
        [InlineData(Orientations.West, 0, 1)]
        [InlineData(Orientations.North, 1, 2)]
        [InlineData(Orientations.South, 1, 0)]
        public void Execute_WithValidRobotOrientation_SetsValidRobotPosition(Orientations orientation, int expectedX, int expectedY)
        {
            //  Arrange
            var fakeRobot = new Robot(new Coordinate(1, 1), orientation);
            var command = new FrontMoveCommand();
            var expectedCoordinate = new Coordinate(expectedX, expectedY);
            
            // Act
            command.Execute(fakeRobot);

            // Asset
            Assert.Equal(expectedCoordinate, fakeRobot.Position);
        }

        [Fact]
        public void Execute_WithInvalidRobotOrientation_NotChangesRoborPosition()
        {
            //  Arrange
            var initialPosition = new Coordinate(1, 1);
            var fakeRobot = new Robot(initialPosition, (Orientations)5);
            var command = new FrontMoveCommand();

            // Act
            command.Execute(fakeRobot);

            // Asset
            Assert.Equal(initialPosition, fakeRobot.Position);
        }
    }
}
