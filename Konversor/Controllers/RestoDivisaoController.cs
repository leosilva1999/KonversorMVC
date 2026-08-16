using Microsoft.AspNetCore.Mvc;
using Konversor.Services;
using Konversor.ViewModels;

namespace Konversor.Controllers
{
    public class RestoDivisaoController : Controller
    {
        private readonly IRestoDivisaoService _restoDivisaoService;

        public RestoDivisaoController(IRestoDivisaoService restoDivisaoService)
        {
            _restoDivisaoService = restoDivisaoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new RestoDivisaoViewModel());
        }

        [HttpPost]
        public IActionResult CalculateRestoDivisao(RestoDivisaoViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Index", vm);

                vm.Result = _restoDivisaoService.Resto(vm.Dividendo!.Value, vm.Divisor!.Value);
            }
            catch (Exception ex)
            {
                vm.Error = ex.Message;
            }

            return View("Index", vm);
        }
    }
}
