namespace Konversor.Services
{
    public class RestoDivisaoService : IRestoDivisaoService
    {
        public int Resto(int dividendo, int divisor)
        {
            if (dividendo <= 0 || divisor <= 0)
                throw new Exception("Entrada inválida!");

            return dividendo % divisor;
        }
    }
}
