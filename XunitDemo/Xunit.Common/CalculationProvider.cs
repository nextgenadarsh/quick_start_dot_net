
using System.Security.Cryptography;

namespace Xunit.Common
{
    public class CalculationProvider : ICalculationProvider<int>
    {
        public Task<int> DivideAsyc(int first, int second)
        {
            return Task.FromResult(first/second);
        }

        public Task<int> MultiplyAsyc(int first, int second)
        {
            return Task.FromResult(first * second);
        }

        public int Sum(int first, int second)
        {
            return first + second + RandomNumberGenerator.GetInt32(10, 20);
        }
    }
}
