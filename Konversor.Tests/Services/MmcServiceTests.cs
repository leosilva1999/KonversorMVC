using Konversor.Services;

namespace Konversor.Tests.Services
{
    public class MmcServiceTests
    {
        private readonly MmcService _service = new();

        [Theory]
        [InlineData(4, 6, 12)]
        [InlineData(3, 5, 15)]
        [InlineData(7, 7, 7)]
        [InlineData(1, 1, 1)]
        [InlineData(21, 6, 42)]
        public void Mmc_ValidInputs_ReturnsExpectedResult(int num1, int num2, int expected)
        {
            var result = _service.Mmc(num1, num2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 5)]
        [InlineData(5, 0)]
        [InlineData(-3, 5)]
        [InlineData(5, -3)]
        [InlineData(-3, -3)]
        public void Mmc_InvalidInputs_ThrowsException(int num1, int num2)
        {
            var ex = Assert.Throws<Exception>(() => _service.Mmc(num1, num2));

            Assert.Equal("Entrada inválida!", ex.Message);
        }
    }
}
