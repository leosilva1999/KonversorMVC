using Microsoft.AspNetCore.Mvc;
using Konversor.Services;
using Konversor.ViewModels;

namespace Konversor.Controllers
{
    public class MmcController : Controller
    {
        private readonly IMmcService _mmcService;

        public MmcController(IMmcService mmcService)
        {
            _mmcService = mmcService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new MmcViewModel());
        }

        [HttpPost]
        public IActionResult CalculateMmc(MmcViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Index", vm);

                vm.Result = _mmcService.Mmc(vm.Num1!.Value, vm.Num2!.Value);
            }
            catch (Exception ex)
            {
                vm.Error = ex.Message;
            }

            return View("Index", vm);
        }
    }
}
