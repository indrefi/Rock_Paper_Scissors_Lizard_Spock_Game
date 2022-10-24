using MediatR;

namespace Application.UseCases.AvailableChoises.PlayGameMultiPlayer.Queries
{
    public class GetGameMultiPlayerResultQuery : IRequest<GameMultiPlayerResultDto>
    {
        public int PlayerOne { get; set; }
        public int PlayerTwo { get; set; }
    }
}