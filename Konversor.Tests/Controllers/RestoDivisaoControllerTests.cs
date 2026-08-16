using Konversor.Controllers;
using Konversor.Services;
using Konversor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Konversor.Tests.Controllers
{
    public class RestoDivisaoControllerTests
    {
        private readonly IRestoDivisaoService _restoDivisaoService = Substitute.For<IRestoDivisaoService>();
        private readonly RestoDivisaoController _controller;

        public RestoDivisaoControllerTests()
        {
            _controller = new RestoDivisaoController(_restoDivisaoService);
        }

        [Fact]
        public void Index_Get_ReturnsViewWithEmptyViewModel()
        {
            var result = Assert.IsType<ViewResult>(_controller.Index());
            var model = Assert.IsType<RestoDivisaoViewModel>(result.Model);

            Assert.Null(model.Dividendo);
            Assert.Null(model.Divisor);
            Assert.Null(model.Result);
            Assert.Null(model.Error);
        }

        [Fact]
        public void CalculateRestoDivisao_InvalidModelState_ReturnsViewWithoutCallingService()
        {
            _controller.ModelState.AddModelError("Dividendo", "Required");
            var vm = new RestoDivisaoViewModel { Divisor = 5 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateRestoDivisao(vm));

            Assert.Equal("Index", result.ViewName);
            Assert.Same(vm, result.Model);
            _restoDivisaoService.DidNotReceive().Resto(Arg.Any<int>(), Arg.Any<int>());
        }

        [Fact]
        public void CalculateRestoDivisao_ValidInput_SetsResultFromService()
        {
            _restoDivisaoService.Resto(17, 5).Returns(2);
            var vm = new RestoDivisaoViewModel { Dividendo = 17, Divisor = 5 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateRestoDivisao(vm));
            var model = Assert.IsType<RestoDivisaoViewModel>(result.Model);

            Assert.Equal(2, model.Result);
            Assert.Null(model.Error);
        }

        [Fact]
        public void CalculateRestoDivisao_ServiceThrows_SetsErrorAndKeepsResultNull()
        {
            _restoDivisaoService.Resto(Arg.Any<int>(), Arg.Any<int>())
                .Returns(_ => throw new Exception("Entrada inválida!"));
            var vm = new RestoDivisaoViewModel { Dividendo = -1, Divisor = 5 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateRestoDivisao(vm));
            var model = Assert.IsType<RestoDivisaoViewModel>(result.Model);

            Assert.Equal("Entrada inválida!", model.Error);
            Assert.Null(model.Result);
        }
    }
}
