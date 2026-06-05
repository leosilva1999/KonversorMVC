namespace Konversor.Services
{
    public class PorcentagemService : IPorcentagemService
    {
        public double PercentOf(double numberToCalc, double percent) {
            if (numberToCalc < 0 || percent < 0 || percent > 100)
                throw new Exception("Entrada inválida!");

            return (percent / 100) * numberToCalc;
        }

        public double Num1IsPercentOfNum2(double num1, double num2)
        {
            if (num1 < 0 || num2 < 0 || num1 > num2)
                throw new Exception("Entrada inválida!");
            
            return (num1 / num2) * 100;
        }
        public double IncreasePercentage(double initalValue, double finalValue)
        {
            if (finalValue < 0 || initalValue < 0 || initalValue > finalValue)
                throw new Exception("Entrada inválida!");
            
            return ((finalValue - initalValue) / initalValue) * 100;
        }
    }
}
