using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.UseCases.GameResults.Queries.GetPossibleGameResults
{
    public class GameResultDto : IMapFrom<GameResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GameResult, GameResultDto>()
                  .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                  .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}