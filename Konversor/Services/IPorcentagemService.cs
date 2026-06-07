namespace Konversor.Services
{
    public interface IPorcentagemService
    {
        double PercentOf(double numberToCalc, double percent);
        double Num1IsPercentOfNum2(double num1, double num2);
        double IncreasePercentage(double initalValue, double finalValue);
        double DecreasePercentage(double initalValue, double finalValue);
        double PercentOfXOverY(double valueX, double valueY);
        double IncreasePercentageOnValue(double value, double percentage);
        double DecreasePercentageOnValue(double value, double percentage);
    }
}
