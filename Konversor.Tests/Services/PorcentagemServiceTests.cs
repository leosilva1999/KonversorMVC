using Konversor.Services;

namespace Konversor.Tests.Services
{
    public class PorcentagemServiceTests
    {
        private const string InvalidInputMessage = "Entrada inválida!";

        private readonly PorcentagemService _service = new();

        // PercentOf

        [Theory]
        [InlineData(200, 10, 20)]
        [InlineData(0, 50, 0)]
        [InlineData(100, 0, 0)]
        [InlineData(100, 100, 100)]
        public void PercentOf_ValidInputs_ReturnsExpectedResult(double numberToCalc, double percent, double expected)
        {
            var result = _service.PercentOf(numberToCalc, percent);

            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(-1, 10)]
        [InlineData(10, -1)]
        [InlineData(10, 101)]
        public void PercentOf_InvalidInputs_ThrowsException(double numberToCalc, double percent)
        {
            var ex = Assert.Throws<Exception>(() => _service.PercentOf(numberToCalc, percent));

            Assert.Equal(InvalidInputMessage, ex.Message);
        }

        // Num1IsPercentOfNum2

        [Theory]
        [InlineData(50, 200, 25)]
        [InlineData(0, 10, 0)]
        [InlineData(10, 10, 100)]
        public void Num1IsPercentOfNum2_ValidInputs_ReturnsExpectedResult(double num1, double num2, double expected)
        {
            var result = _service.Num1IsPercentOfNum2(num1, num2);

            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(-1, 10)]
        [InlineData(10, -1)]
        [InlineData(20, 10)]
        public void Num1IsPercentOfNum2_InvalidInputs_ThrowsException(double num1, double num2)
        {
            var ex = Assert.Throws<Exception>(() => _service.Num1IsPercentOfNum2(num1, num2));

            Assert.Equal(InvalidInputMessage, ex.Message);
        }

        // IncreasePercentage

        [Theory]
        [InlineData(100, 150, 50)]
        [InlineData(50, 50, 0)]
        public void IncreasePercentage_ValidInputs_ReturnsExpectedResult(double initialValue, double finalValue, double expected)
        {
            var result = _service.IncreasePercentage(initialValue, finalValue);

            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(-1, 100)]
        [InlineData(100, -1)]
        [InlineData(150, 100)]
        [InlineData(0, 100)]
        public void IncreasePercentage_InvalidInputs_ThrowsException(double initialValue, double finalValue)
        {
            var ex = Assert.Throws<Exception>(() => _service.IncreasePercentage(initialValue, finalValue));

            Assert.Equal(InvalidInputMessage, ex.Message);
        }

        // DecreasePercentage

        [Theory]
        [InlineData(100, 50, -50)]
        [InlineData(100, 60, -40)]
        [InlineData(100, 100, 0)]
        public void DecreasePercentage_ValidInputs_ReturnsExpectedResult(double initialValue, double finalValue, double expected)
        {
            var result = _service.DecreasePercentage(initialValue, finalValue);

            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(-1, 50)]
        [InlineData(100, -1)]
        [InlineData(50, 100)]
        [InlineData(0, 0)]
        public void DecreasePercentage_InvalidInputs_ThrowsException(double initialValue, double finalValue)
        {
            var ex = Assert.Throws<Exception>(() => _service.DecreasePercentage(initialValue, finalValue));

            Assert.Equal(InvalidInputMessage, ex.Message);
        }

        // PercentOfXOverY

        [Theory]
        [InlineData(25, 100, 25)]
        [InlineData(0, 10, 0)]
        [InlineData(10, 10, 100)]
        public void PercentOfXOverY_ValidInputs_ReturnsExpectedResult(double valueX, double valueY, double expected)
        {
            var result = _service.PercentOfXOverY(valueX, valueY);

            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(-1, 10)]
        [InlineData(10, -1)]
        [InlineData(20, 10)]
        public void PercentOfXOverY_InvalidInputs_ThrowsException(double valueX, double valueY)
        {
            var ex = Assert.Throws<Exception>(() => _service.PercentOfXOverY(valueX, valueY));

            Assert.Equal(InvalidInputMessage, ex.Message);
        }

        // IncreasePercentageOnValue

        [Theory]
        [InlineData(100, 10, 110)]
        [InlineData(100, 0, 100)]
        [InlineData(0, 10, 0)]
        public void IncreasePercentageOnValue_ValidInputs_ReturnsExpectedResult(double value, double percentage, double expected)
        {
            var result = _service.IncreasePercentageOnValue(value, percentage);

            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(-1, 10)]
        [InlineData(10, -1)]
        public void IncreasePercentageOnValue_InvalidInputs_ThrowsException(double value, double percentage)
        {
            var ex = Assert.Throws<Exception>(() => _service.IncreasePercentageOnValue(value, percentage));

            Assert.Equal(InvalidInputMessage, ex.Message);
        }

        // DecreasePercentageOnValue

        [Theory]
        [InlineData(100, 10, 90)]
        [InlineData(100, 0, 100)]
        [InlineData(100, 100, 0)]
        public void DecreasePercentageOnValue_ValidInputs_ReturnsExpectedResult(double value, double percentage, double expected)
        {
            var result = _service.DecreasePercentageOnValue(value, percentage);

            Assert.Equal(expected, result, precision: 10);
        }

        [Theory]
        [InlineData(-1, 10)]
        [InlineData(10, -1)]
        [InlineData(10, 101)]
        public void DecreasePercentageOnValue_InvalidInputs_ThrowsException(double value, double percentage)
        {
            var ex = Assert.Throws<Exception>(() => _service.DecreasePercentageOnValue(value, percentage));

            Assert.Equal(InvalidInputMessage, ex.Message);
        }
    }
}
