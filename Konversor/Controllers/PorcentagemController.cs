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
            try
            {
                if (!ModelState.IsValid)
                    return View("Index");

                vm.Result = _porcentagemService.PercentOf(vm.Value!.Value, vm.Percentage!.Value);
            }
            catch (Exception ex)
            {
                vm.Error = ex.Message;
            }

            var pageVm = new PorcentagemPageViewModel
            {
                PercentOf = vm
            };

            return View("Index", pageVm);
        }

        [HttpPost]
        public IActionResult CalculateNum1IsPercentOfNum2(Num1IsPercentOfNum2ViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Index");

                vm.Result = _porcentagemService.Num1IsPercentOfNum2(vm.Num1!.Value, vm.Num2!.Value);


            }
            catch (Exception ex)
            {
                vm.Error = ex.Message;
            }

            var pageVm = new PorcentagemPageViewModel
            {
                Num1IsPercentOfNum2 = vm
            };

            return View("Index", pageVm);
        }

        [HttpPost]
        public IActionResult CalculateIncreasePercentOf(IncreasePercentageViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Index");

                vm.Result = _porcentagemService.IncreasePercentage(vm.InitialValue!.Value, vm.FinalValue!.Value);


            }
            catch (Exception ex)
            {
                vm.Error = ex.Message;
            }

            var pageVm = new PorcentagemPageViewModel
            {
                IncreasePercentage = vm
            };

            return View("Index", pageVm);
        }


    }
}
