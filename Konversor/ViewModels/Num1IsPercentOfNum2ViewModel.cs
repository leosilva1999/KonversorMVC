using System.ComponentModel.DataAnnotations;

namespace Konversor.ViewModels
{
    public class Num1IsPercentOfNum2ViewModel
    {
        [Required]
        public double? Num1 { get; set; }

        [Required]
        public double? Num2 { get; set; }

        public double? Result { get; set; }

        public string? Error { get; set; }
    }
}
