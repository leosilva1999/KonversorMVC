using System.ComponentModel.DataAnnotations;

namespace Konversor.ViewModels
{
    public class DecreasePercentageOnValueViewModel
    {
        [Required]
        public double? Value { get; set; }

        [Required]
        public double? Percentage { get; set; }

        public double? Result { get; set; }

        public string? Error { get; set; }
    }
}


