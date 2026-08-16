using Konversor.Services;

namespace Konversor.Tests.Services
{
    public class MdcServiceTests
    {
        private readonly MdcService _service = new();

        [Theory]
        [InlineData(48, 18, 6)]
        [InlineData(12, 8, 4)]
        [InlineData(7, 7, 7)]
        [InlineData(1, 1, 1)]
        [InlineData(21, 6, 3)]
        public void Mdc_ValidInputs_ReturnsExpectedResult(int num1, int num2, int expected)
        {
            var result = _service.Mdc(num1, num2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 5)]
        [InlineData(5, 0)]
        [InlineData(-3, 5)]
        [InlineData(5, -3)]
        [InlineData(-3, -3)]
        public void Mdc_InvalidInputs_ThrowsException(int num1, int num2)
        {
            var ex = Assert.Throws<Exception>(() => _service.Mdc(num1, num2));

            Assert.Equal("Entrada inválida!", ex.Message);
        }
    }
}
