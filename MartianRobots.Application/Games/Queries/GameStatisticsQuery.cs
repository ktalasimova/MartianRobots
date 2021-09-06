using MartianRobots.Application.Games.DTOs;
using MediatR;
using System.Collections.Generic;

namespace MartianRobots.Application.Games.Queries
{
    public class GameStatisticsQuery : IRequest<IList<GamesStatisticDTO>>
    {
    }
}
