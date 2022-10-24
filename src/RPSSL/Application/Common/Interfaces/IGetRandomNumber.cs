using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IGetRandomNumber
    {
        public Task<int> GetRandomNumber(int min = 0 , int max = 100);
    }
}