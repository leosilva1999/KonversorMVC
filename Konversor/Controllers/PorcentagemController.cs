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
                if (ModelState.IsValid)
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
                if (ModelState.IsValid)
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
                if (ModelState.IsValid)
                    vm.Result = _porcentagemService.IncreasePercentage(vm.IncreaseInitialValue!.Value, vm.IncreaseFinalValue!.Value);


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
        [HttpPost]
        public IActionResult CalculateDecreasePercentOf(DecreasePercentageViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                    vm.Result = _porcentagemService.DecreasePercentage(vm.DecreaseInitialValue!.Value, vm.DecreaseFinalValue!.Value);


            }
            catch (Exception ex)
            {
                vm.Error = ex.Message;
            }

            var pageVm = new PorcentagemPageViewModel
            {
                DecreasePercentage = vm
            };

            return View("Index", pageVm);
        }
        [HttpPost]
        public IActionResult CalculatePercentOfXOverY(PercentOfXOverYViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                    vm.Result = _porcentagemService.PercentOfXOverY(vm.ValueX!.Value, vm.ValueY!.Value);


            }
            catch (Exception ex)
            {
                vm.Error = ex.Message;
            }

            var pageVm = new PorcentagemPageViewModel
            {
                PercentOfXOverY = vm
            };

            return View("Index", pageVm);
        }
        public IActionResult CalculateIncreasePercentageOnValue(IncreasePercentageOnValueViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                    vm.Result = _porcentagemService.IncreasePercentageOnValue(vm.ValueToIncrease!.Value, vm.IncreasePercentage!.Value);


            }
            catch (Exception ex)
            {
                vm.Error = ex.Message;
            }

            var pageVm = new PorcentagemPageViewModel
            {
                IncreasePercentageOnValue = vm
            };

            return View("Index", pageVm);
        }
        public IActionResult CalculateDecreasePercentageOnValue(DecreasePercentageOnValueViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                    vm.Result = _porcentagemService.DecreasePercentageOnValue(vm.ValueToDecrease!.Value, vm.DecreasePercentage!.Value);


            }
            catch (Exception ex)
            {
                vm.Error = ex.Message;
            }

            var pageVm = new PorcentagemPageViewModel
            {
                DecreasePercentageOnValue = vm
            };

            return View("Index", pageVm);
        }


    }
}
