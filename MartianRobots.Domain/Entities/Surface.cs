using System;
using System.Collections.Generic;

namespace MartianRobots.Domain.Entities
{
    public class Surface
    {
        private Coordinate upperRightCorner;
        private Coordinate lowerLeftCorner;

        private readonly HashSet<Coordinate> exploredSurfaces = new();

        public Surface(Coordinate upperRightCorner)
        {
            this.upperRightCorner = upperRightCorner;
            lowerLeftCorner = new Coordinate(0, 0);
        }

        public bool OutOfTheBound(Coordinate coordinate)
        {
            return coordinate.X > upperRightCorner.X || coordinate.X < lowerLeftCorner.X
                || coordinate.Y > upperRightCorner.Y || coordinate.Y < lowerLeftCorner.Y;
        }

        public void Explore(Coordinate coordinate)
        {
            if (OutOfTheBound(coordinate))
            {
                throw new InvalidOperationException("Failed to explore surface.");
            }

            if (!exploredSurfaces.Contains(coordinate))
            {
                exploredSurfaces.Add(coordinate);
            }
        }

        public double GetExploredRate()
        {
            var exploredArea = exploredSurfaces.Count;
            var totalArea = (upperRightCorner.X - lowerLeftCorner.X) * (upperRightCorner.Y - lowerLeftCorner.Y);

            return (exploredArea / totalArea) * 100;
        }
    }
}
