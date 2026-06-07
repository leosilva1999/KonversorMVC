namespace Konversor.ViewModels
{
    public class PorcentagemPageViewModel
    {
        public PercentOfViewModel PercentOf { get; set; }
        = new();

        public Num1IsPercentOfNum2ViewModel Num1IsPercentOfNum2 { get; set; }
        = new();

        public IncreasePercentageViewModel IncreasePercentage { get; set; }
        = new();

        public DecreasePercentageViewModel DecreasePercentage { get; set; }
        = new();

        public PercentOfXOverYViewModel PercentOfXOverY { get; set; }
        = new();
        public IncreasePercentageOnValueViewModel IncreasePercentageOnValue { get; set; }
        = new();

        public DecreasePercentageOnValueViewModel DecreasePercentageOnValue { get; set; }
        = new();

    }
}