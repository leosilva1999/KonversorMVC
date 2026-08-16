using Konversor.Services;

namespace Konversor.Tests.Services
{
    public class RestoDivisaoServiceTests
    {
        private readonly RestoDivisaoService _service = new();

        [Theory]
        [InlineData(17, 5, 2)]
        [InlineData(10, 2, 0)]
        [InlineData(7, 7, 0)]
        [InlineData(1, 1, 0)]
        [InlineData(20, 6, 2)]
        public void Resto_ValidInputs_ReturnsExpectedResult(int dividendo, int divisor, int expected)
        {
            var result = _service.Resto(dividendo, divisor);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 5)]
        [InlineData(5, 0)]
        [InlineData(-3, 5)]
        [InlineData(5, -3)]
        [InlineData(-3, -3)]
        public void Resto_InvalidInputs_ThrowsException(int dividendo, int divisor)
        {
            var ex = Assert.Throws<Exception>(() => _service.Resto(dividendo, divisor));

            Assert.Equal("Entrada inválida!", ex.Message);
        }
    }
}
