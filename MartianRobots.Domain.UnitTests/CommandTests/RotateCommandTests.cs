using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Commands;
using Xunit;

namespace MartianRobots.Domain.UnitTests.CommandTests
{
    public class RotateCommandTests
    {
        [Theory]
        // Left rotate
        [InlineData(RotateDirections.Left, Orientations.East, Orientations.North)]
        [InlineData(RotateDirections.Left, Orientations.North, Orientations.West)]
        [InlineData(RotateDirections.Left, Orientations.West, Orientations.South)]
        [InlineData(RotateDirections.Left, Orientations.South, Orientations.East)]
        // Right rotate
        [InlineData(RotateDirections.Right, Orientations.East, Orientations.South)]
        [InlineData(RotateDirections.Right, Orientations.South, Orientations.West)]
        [InlineData(RotateDirections.Right, Orientations.West, Orientations.North)]
        [InlineData(RotateDirections.Right, Orientations.North, Orientations.East)]
        public void Execute_WithLeftDirection_SetCorrectOrientation(RotateDirections rotateDirections, Orientations initialOrientation, Orientations expectedOrientation)
        {
            // Arrange
            var fakeRobot = new Robot(new Coordinate(1, 1), initialOrientation);
            var command = new RotateCommand(rotateDirections);

            // Act
            command.Execute(fakeRobot);

            // Assert
            Assert.Equal(expectedOrientation, fakeRobot.Orientation);
        }
    }
}
