using Application.Common.Extensions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.RandomNumber
{
    public class GetExternalRandomNumberService : IGetRandomNumber
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ExternalRandomNumberConfigurations _externalRandomNumberOptions;
        
        public GetExternalRandomNumberService(IHttpClientFactory httpClientFactory, IOptions<ExternalRandomNumberConfigurations> externalRandomNumberOptions)
        {
            _httpClientFactory = httpClientFactory;
            _externalRandomNumberOptions = externalRandomNumberOptions.Value;
        }

        public async Task<int> GetRandomNumber(int minValue, int maxValue)
        {
            if (string.IsNullOrEmpty(_externalRandomNumberOptions.Url))
            {
                return RandomNumberExtensions.GetARandomNumber(minValue, maxValue);
            }
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, _externalRandomNumberOptions.Url);          
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
                var randomNumberResult = JsonConvert.DeserializeObject<RandomNumber>(contentStream);
                return randomNumberResult.random_number;
            }
            else
            {
                return RandomNumberExtensions.GetARandomNumber(minValue, maxValue);
            }
        }

        private class RandomNumber
        {
            public int random_number;
        }
    }
}