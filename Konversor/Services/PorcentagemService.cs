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

        public double DecreasePercentage(double initalValue, double finalValue)
        {
            if (finalValue < 0 || initalValue < 0 || initalValue < finalValue)
                throw new Exception("Entrada inválida!");
            
            return ((finalValue - initalValue) / initalValue) * 100;
        }

        public double PercentOfXOverY(double valueX, double valueY)
        {
            if (valueX < 0 || valueY < 0 || valueX > valueY)
                throw new Exception("Entrada inválida!");
            
            return (valueX / valueY) * 100;
        }
        public double IncreasePercentageOnValue(double value, double percentage)
        {
            if (value < 0 || percentage < 0)
                throw new Exception("Entrada inválida!");
                
            
            return value * ((percentage / 100) + 1);
        }

        public double DecreasePercentageOnValue(double value, double percentage)
        {
            if (value < 0 || percentage < 0 || percentage > 100)
                throw new Exception("Entrada inválida!");

            double valueToDecrease = (value / 100) * percentage;
            
            return value - valueToDecrease;
        }
    }
}
