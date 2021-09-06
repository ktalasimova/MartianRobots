using MartianRobots.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MartianRobots.Persistence.Configurations
{
    public static class CoordinatePropertyBuilderExtensions
    {
        public static PropertyBuilder<Coordinate> UseStringConvension(this PropertyBuilder<Coordinate> builder)
        {
            return builder.HasConversion(c => c.ToString(), c => new Coordinate(c));
        }
    }
}
