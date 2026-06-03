namespace Konversor.Services
{
    public class MmcService : IMmcService
    {
        public int Mmc(int num1, int num2)
        {
            if (num1 < 0 || num2 < 0 || num2 > 100)
                throw new Exception("Invalid input");

            return (num2 / 100) * num2;
        }
    }
}
