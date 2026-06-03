using System.ComponentModel.DataAnnotations;

namespace Konversor.ViewModels
{
    public class PercentOfViewModel
    {
        [Required]
        public double? Value { get; set; }

        [Required]
        public double? Percentage { get; set; }

        public double? Result { get; set; }
    }
}
