using System;

namespace Application.Common.Exceptions
{
    public class CalculateGameResultException : Exception
    {
        public CalculateGameResultException()
            : base()
        {
        }

        public CalculateGameResultException(string message)
            : base(message)
        {
        }
    }
}
