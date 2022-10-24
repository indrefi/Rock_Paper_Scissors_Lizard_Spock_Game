using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.UseCases.AvailableChoises.Queries.GetAvailableChoises
{
    public class AvailableChoisesDto : IMapFrom<Choise>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Choise, AvailableChoisesDto>()
                  .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                  .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));
        }
    }
}