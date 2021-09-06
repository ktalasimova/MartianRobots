using AutoMapper;
using MartianRobots.Application.Games.DTOs;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MartianRobots.Application.Games.Commands
{
    public class RunGameCommandHandler : IRequestHandler<RunGameCommand, IList<GameResultDTO>>
    {
        private readonly IRepository<Game, Guid> _gamesRepository;
        private readonly IMapper _mapper;

        public RunGameCommandHandler(IRepository<Game, Guid> gamesRepository, IMapper mapper)
        {
            _gamesRepository = gamesRepository;
            _mapper = mapper;
        }

        public async Task<IList<GameResultDTO>> Handle(RunGameCommand request, CancellationToken cancellationToken)
        {
            var surface = new Surface(request.UpperRightCornerCoordinate);

            var game = new Game(surface);
            var results = new List<GameResultDTO>();

            foreach (var robotDTO in request.Robots)
            {
                var robot = new Robot(robotDTO.Position, robotDTO.Orientation);

                game.AddRobot(robot);
                var result = game.RunGame(robotDTO.Instructions);

                results.Add(_mapper.Map<GameResultDTO>(result));
            }

            await _gamesRepository.AddAsync(game);
            await _gamesRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return results;
        }
    }
}
