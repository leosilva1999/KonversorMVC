namespace Konversor.Services
{
    public class MmcService : IMmcService
    {
        public int Mmc(int num1, int num2)
        {
            if (num1 <= 0 || num2 <= 0)
                throw new Exception("Entrada inválida!");

            return (num1 / Mdc(num1, num2)) * num2;
        }

        private static int Mdc(int num1, int num2)
        {
            while (num2 != 0)
            {
                (num1, num2) = (num2, num1 % num2);
            }

            return num1;
        }
    }
}
