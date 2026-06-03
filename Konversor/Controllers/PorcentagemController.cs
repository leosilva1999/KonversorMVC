using Microsoft.AspNetCore.Mvc;
using Konversor.Services;
using Konversor.ViewModels;

namespace Konversor.Controllers
{
    public class PorcentagemController : Controller
    {
        private readonly IPorcentagemService _porcentagemService;

        public PorcentagemController(IPorcentagemService porcentagemService)
        {
            _porcentagemService = porcentagemService;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View(new PorcentagemPageViewModel());
        }

        [HttpPost]
        public IActionResult CalculatePercentOf(PercentOfViewModel vm)
        {
            if(!ModelState.IsValid)                
                    return View("Index");
                
            vm.Result = _porcentagemService.PercentOf(vm.Value!.Value, vm.Percentage!.Value);

            var pageVm = new PorcentagemPageViewModel { 
                PercentOf = vm
            };

            return View("Index", pageVm);
        }


    }
}
