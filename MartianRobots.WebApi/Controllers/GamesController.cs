using MartianRobots.Application.Games.Commands;
using MartianRobots.Application.Games.DTOs;
using MartianRobots.Application.Games.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartianRobots.WebApi.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IList<GamesStatisticDTO>> GetStatistic()
        {
            return await _mediator.Send(new GameStatisticsQuery());
        }

        [HttpPost]
        public async Task<IList<GameResultDTO>> RunGame([FromBody] RunGameCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
