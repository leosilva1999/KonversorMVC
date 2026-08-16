using System.ComponentModel.DataAnnotations;

namespace Konversor.ViewModels
{
    public class IncreasePercentageOnValueViewModel
    {
        [Required]
        public double? ValueToIncrease { get; set; }

        [Required]
        public double? IncreasePercentage { get; set; }

        public double? Result { get; set; }

        public string? Error { get; set; }
    }
}

