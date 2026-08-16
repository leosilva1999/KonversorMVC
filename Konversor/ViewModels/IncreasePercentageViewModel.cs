using System.ComponentModel.DataAnnotations;

namespace Konversor.ViewModels
{
    public class IncreasePercentageViewModel
    {
        [Required]
        public double? IncreaseInitialValue { get; set; }

        [Required]
        public double? IncreaseFinalValue { get; set; }

        public double? Result { get; set; }

        public string? Error { get; set; }
    }
}
