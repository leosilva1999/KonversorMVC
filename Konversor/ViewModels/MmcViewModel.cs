using System.ComponentModel.DataAnnotations;

namespace Konversor.ViewModels
{
    public class MmcViewModel
    {
        [Required]
        public int? Num1 { get; set; }

        [Required]
        public int? Num2 { get; set; }

        public int? Result { get; set; }

        public string? Error { get; set; }
    }
}
