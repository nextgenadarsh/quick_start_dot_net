
namespace Xunit.Common
{
    public interface ICalculationProvider<T>
    {
        Task<T> DivideAsyc(T first, T second);
        T Sum(T first, T second);
        Task<T> MultiplyAsyc(T first, T second);
    }
}
