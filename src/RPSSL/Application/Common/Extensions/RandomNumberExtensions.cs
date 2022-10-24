using System;

namespace Application.Common.Extensions
{
    public static class RandomNumberExtensions
    {
        public static int GetARandomNumber(int min, int max) => new Random(max).Next(min, max);
    }
}
