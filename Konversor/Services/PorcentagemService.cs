namespace Konversor.Services
{
    public class PorcentagemService : IPorcentagemService
    {
        public double PercentOf(double numberToCalc, double percent) {
            if (numberToCalc < 0 || percent < 0 || percent > 100)
                throw new Exception("Invalid input");

            return (percent / 100) * numberToCalc;
        }
    }
}
