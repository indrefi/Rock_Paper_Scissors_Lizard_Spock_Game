using Application.Common.Interfaces;
using Application.UseCases.AvailableChoises.Queries.GetAvailableChoises;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.QueryHandlers.AvailableChoises
{
    public class GetAvailableChoisesQueryHandler : IGetAvailableChoisesQueryHandler
    {
        private readonly IGameDbContext _context;
        private readonly IMapper _mapper;

        public GetAvailableChoisesQueryHandler(IGameDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AvailableChoisesDto>> Handle(GetAvailableChoisesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Choises
                .ProjectTo<AvailableChoisesDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}