using System.ComponentModel.DataAnnotations;

namespace Konversor.ViewModels
{
    public class PercentOfXOverYViewModel
    {
        [Required]
        public double? ValueX { get; set; }

        [Required]
        public double? ValueY { get; set; }

        public double? Result { get; set; }

        public string? Error { get; set; }
    }
}
