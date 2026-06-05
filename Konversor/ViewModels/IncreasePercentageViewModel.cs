using System.ComponentModel.DataAnnotations;

namespace Konversor.ViewModels
{
    public class IncreasePercentageViewModel
    {
        [Required]
        public double? InitialValue { get; set; }

        [Required]
        public double? FinalValue { get; set; }

        public double? Result { get; set; }

        public string? Error { get; set; }
    }
}
