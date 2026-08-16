using Microsoft.AspNetCore.Mvc;
using Konversor.Services;
using Konversor.ViewModels;

namespace Konversor.Controllers
{
    public class MdcController : Controller
    {
        private readonly IMdcService _mdcService;

        public MdcController(IMdcService mdcService)
        {
            _mdcService = mdcService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new MdcViewModel());
        }

        [HttpPost]
        public IActionResult CalculateMdc(MdcViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Index", vm);

                vm.Result = _mdcService.Mdc(vm.Num1!.Value, vm.Num2!.Value);
            }
            catch (Exception ex)
            {
                vm.Error = ex.Message;
            }

            return View("Index", vm);
        }
    }
}
