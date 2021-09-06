using System.Collections.Generic;

namespace MartianRobots.Application.Games.DTOs
{
    public class GamesStatisticDTO
    {
        public int LostRobots { get; set; }

        public int WonRobots { get; set; }

        public int TotalRobots { get; set; }

        public double ExploredSurfaceRate { get; set; }

        public List<GameResultDTO> Results { get; set; }
    }
}
