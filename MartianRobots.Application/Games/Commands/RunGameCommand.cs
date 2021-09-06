using MartianRobots.Application.Games.DTOs;
using MartianRobots.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace MartianRobots.Application.Games.Commands
{
    public class RunGameCommand : IRequest<IList<GameResultDTO>>
    {
        public Coordinate UpperRightCornerCoordinate { get; set; }

        public List<RobotDTO> Robots { get; set; }
    }
}
