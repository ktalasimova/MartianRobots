using AutoMapper;
using MartianRobots.Application.Games.DTOs;
using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MartianRobots.Application.Games.Queries
{
    public class GameStatisticsQueryHandler : IRequestHandler<GameStatisticsQuery, IList<GamesStatisticDTO>>
    {
        private readonly IRepository<Game, Guid> _gamesRepository;
        private readonly IMapper _mapper;

        public GameStatisticsQueryHandler(IRepository<Game, Guid> gamesRepository, IMapper mapper)
        {
            _gamesRepository = gamesRepository;
            _mapper = mapper;
        }

        public async Task<IList<GamesStatisticDTO>> Handle(GameStatisticsQuery request, CancellationToken cancellationToken)
        {
            var games = await _gamesRepository.ToListAsync(null, x => x.GameResults);

            return _mapper.Map<List<GamesStatisticDTO>>(games);
        }
    }
}
