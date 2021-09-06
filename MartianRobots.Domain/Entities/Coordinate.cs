namespace MartianRobots.Domain.Entities
{
    public struct Coordinate
    {
        private int x;
        private int y;

        public int X 
        {
            get => x;
            set 
            {
                x = value;
            }  
        }

        public int Y
        {
            get => y;
            set
            {
                 y = value;
            }
        }

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Coordinate(string value)
        {
            var coordinates = value.Split(" ");
            this.x = int.Parse(coordinates[0]);
            this.y = int.Parse(coordinates[1]);
        }

        public override string ToString()
        {
            return $"{X} {Y}";
        }
    }
}
