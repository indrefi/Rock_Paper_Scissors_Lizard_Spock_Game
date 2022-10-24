using Application.Common.Interfaces;
using System;

namespace Infrastructure.RandomNumber
{
    public class GetExternalRandomNumberService : IGetRandomNumber
    {
        public GetExternalRandomNumberService()
        {
        }

        public int GetRandomNumber()
        {
            var random = new Random(100);

            return random.Next(0,100) % 5;
        }
    }
}
