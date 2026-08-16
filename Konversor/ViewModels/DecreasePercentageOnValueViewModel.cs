using System.ComponentModel.DataAnnotations;

namespace Konversor.ViewModels
{
    public class DecreasePercentageOnValueViewModel
    {
        [Required]
        public double? ValueToDecrease { get; set; }

        [Required]
        public double? DecreasePercentage { get; set; }

        public double? Result { get; set; }

        public string? Error { get; set; }
    }
}


