using System.ComponentModel.DataAnnotations;

namespace Konversor.ViewModels
{
    public class RestoDivisaoViewModel
    {
        [Required]
        public int? Dividendo { get; set; }

        [Required]
        public int? Divisor { get; set; }

        public int? Result { get; set; }

        public string? Error { get; set; }
    }
}
