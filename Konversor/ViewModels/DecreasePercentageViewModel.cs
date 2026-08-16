using System.ComponentModel.DataAnnotations;

namespace Konversor.ViewModels
{
    public class DecreasePercentageViewModel
    {
        [Required]
        public double? DecreaseInitialValue { get; set; }

        [Required]
        public double? DecreaseFinalValue { get; set; }

        public double? Result { get; set; }

        public string? Error { get; set; }
    }
}
