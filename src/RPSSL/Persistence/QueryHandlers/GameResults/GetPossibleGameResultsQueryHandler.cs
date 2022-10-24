using Application.Common.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Application.UseCases.GameResults.Queries.GetPossibleGameResults;

namespace Persistence.QueryHandlers.GameResults
{
    public class GetPossibleGameResultsQueryHandler : IGetPossibleGameResultsQueryHandler
    {
        private readonly IGameDbContext _context;
        private readonly IMapper _mapper;

        public GetPossibleGameResultsQueryHandler(IGameDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GameResultDto>> Handle(GetPossibleGameResultsQuery request, CancellationToken cancellationToken)
        {
            return await _context.GameResults
                .ProjectTo<GameResultDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }

}
