namespace Xunit.Common
{
    public class Calculator : ICalculator
    {
        private readonly ICalculationProvider<int> _calculationProvider;
        public Calculator(ICalculationProvider<int> calculationProvider)
        {
            _calculationProvider = calculationProvider;
        }

        public int Divide(int first, int second)
        {
            return _calculationProvider.DivideAsyc(first, second).Result;
        }

        public int Multiply(int first, int second)
        {
            return _calculationProvider.MultiplyAsyc(first, second).Result;
        }

        public int Sum(int first, int second)
        {
            return _calculationProvider.Sum(first, second);
        }
    }
}
