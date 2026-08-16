namespace Konversor.Services
{
    public class MdcService : IMdcService
    {
        public int Mdc(int num1, int num2)
        {
            if (num1 <= 0 || num2 <= 0)
                throw new Exception("Entrada inválida!");

            while (num2 != 0)
            {
                (num1, num2) = (num2, num1 % num2);
            }

            return num1;
        }
    }
}
