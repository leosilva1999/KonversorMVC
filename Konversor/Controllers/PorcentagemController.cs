using Microsoft.AspNetCore.Mvc;
using Konversor.Services;

namespace Konversor.Controllers
{
    public class PorcentagemController : Controller
    {
        private readonly IPorcentagemService _porcentagemService;

        public PorcentagemController(IPorcentagemService porcentagemService)
        {
            _porcentagemService = porcentagemService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PercentOf(double numberToCalc, double percent)
        {
            var percentOf = _porcentagemService.PercentOf(numberToCalc, percent);

            return View(percentOf);
        }


    }
}
