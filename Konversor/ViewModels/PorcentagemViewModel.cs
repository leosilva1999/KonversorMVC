using System.ComponentModel.DataAnnotations;

namespace Konversor.ViewModels
{
    public class PorcentagemViewModel
    {
        [Required(ErrorMessage = "O valor é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
        [Display(Name = "Valor")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "A porcentagem é obrigatória")]
        [Range(0, 100, ErrorMessage = "A porcentagem deve estar entre 0 e 100")]
        [Display(Name = "Porcentagem (%)")]
        public decimal Percentage { get; set; }

        [Display(Name = "Resultado")]
        public decimal? Result { get; set; }

        public string ResultFormatted =>
            Result.HasValue ? $"{Result.Value:F2}" : "-";

        public bool HasResult => Result.HasValue;
    }
}
