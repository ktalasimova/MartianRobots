using AutoMapper;
using MartianRobots.Application.Games.DTOs;
using MartianRobots.Domain.Entities;

namespace MartianRobots.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GamesStatisticDTO>()
                .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.GameResults));

            CreateMap<GameResult, GameResultDTO>()
                .ForMember(dest => dest.Lost, opt => opt.MapFrom(src => src.HasFallen));
        }
    }
}
