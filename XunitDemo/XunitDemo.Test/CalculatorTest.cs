using FluentAssertions;
using Moq;
using Xunit.Common;

namespace XunitDemo.Test
{
    public class CalculatorTest
    {
        private readonly Mock<ICalculationProvider<int>> _mockCalculationProvider;
        private readonly ICalculator _calculator;

        public CalculatorTest()
        {
            _mockCalculationProvider = new Mock<ICalculationProvider<int>>();
            _mockCalculationProvider.Setup(x => x.DivideAsyc(It.Is<int>(n => n > 0), It.Is<int>(n => n > 0)))
                .ReturnsAsync(10);
            _mockCalculationProvider.Setup(x => x.DivideAsyc(It.Is<int>(n => n > 0), It.Is<int>(n => n == 0)))
                .Throws<InvalidOperationException>();
            _mockCalculationProvider.Setup(x => x.MultiplyAsyc(It.Is<int>(n => n > 0), It.IsAny<int>()))
                .ReturnsAsync(20);
            _mockCalculationProvider.Setup(x => x.Sum(It.Is<int>(n => n > 0), It.IsAny<int>()))
                .Returns(34);

            _calculator = new Calculator(_mockCalculationProvider.Object);
        }

        [Fact]
        public void Divide__ShouldThrowError()
        {
            var action = () => _calculator.Divide(5, 0);
            var exception = action.Should().Throw<InvalidOperationException>().Which;
            exception.Should().BeOfType<InvalidOperationException>();

            _mockCalculationProvider.Verify(x => x.DivideAsyc(It.Is<int>(n => n == 5), It.Is<int>(n => n == 0)), Times.Once);
        }

        [Fact]
        public void Multiply()
        {
            var result = _calculator.Multiply(5, 6);
            result.Should().Be(20);

            _mockCalculationProvider.Verify(x => x.MultiplyAsyc(It.Is<int>(n => n == 5), It.Is<int>(n => n == 6)), Times.Once);
        }

        [Fact]
        public void Sum()
        {
            var result = _calculator.Sum(3, 6);
            result.Should().Be(34);

            _mockCalculationProvider.Verify(x => x.Sum(It.Is<int>(n => n == 3), It.Is<int>(n => n == 6)), Times.Once);
        }
    }
}