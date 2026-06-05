namespace Konversor.Services
{
    public interface IPorcentagemService
    {
        double PercentOf(double numberToCalc, double percent);
        double Num1IsPercentOfNum2(double num1, double num2);
        double IncreasePercentage(double initalValue, double finalValue);
    }
}
