using Application.Common.Interfaces;
using Application.UseCases.AvailableChoises.Queries.GetAvailableChoises;
using System.Threading.Tasks;
using System.Threading;
using Application.UseCases.AvailableChoises.Queries.GetARandomChoise;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Persistence.QueryHandlers.AvailableChoises
{
    public class GetARandomChoiseQueryHandler : IGetARandomChoiseQueryHandler
    {
        private readonly IGameDbContext _context;
        private readonly IMapper _mapper;
        private readonly IGetRandomNumber _getRandomNumber;
        private readonly int _randomMinValue = 0;
        private readonly int _randomMaxValue = 100;

        public GetARandomChoiseQueryHandler(IGameDbContext context, IMapper mapper, IGetRandomNumber getRandomNumber)
        {
            _getRandomNumber = getRandomNumber;
            _context = context;
            _mapper = mapper;
        }

        public async Task<AvailableChoisesDto> Handle(GetARandomChoiseQuery request, CancellationToken cancellationToken)
        {
            var randomNumber = await _getRandomNumber.GetRandomNumber(_randomMinValue, _randomMaxValue);
            var convertedRandomToIdValue = ConvertRandomValueToChoiseIdValue(randomNumber);
            var choiseResult = await _context.Choises
                .Where(x => x.Id == convertedRandomToIdValue)
                .ProjectTo<AvailableChoisesDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return choiseResult.First(); // it is safe to return first since we know that it has always a value by modulo 5.
        }

        private int ConvertRandomValueToChoiseIdValue(int randomNumber)
        {
            var convertedRandomToIdValue = randomNumber % 5;
            convertedRandomToIdValue = convertedRandomToIdValue == 0 ? 1 : convertedRandomToIdValue;

            return convertedRandomToIdValue;
        }
    }

}
