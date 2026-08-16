using Konversor.Controllers;
using Konversor.Services;
using Konversor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Konversor.Tests.Controllers
{
    public class MmcControllerTests
    {
        private readonly IMmcService _mmcService = Substitute.For<IMmcService>();
        private readonly MmcController _controller;

        public MmcControllerTests()
        {
            _controller = new MmcController(_mmcService);
        }

        [Fact]
        public void Index_Get_ReturnsViewWithEmptyViewModel()
        {
            var result = Assert.IsType<ViewResult>(_controller.Index());
            var model = Assert.IsType<MmcViewModel>(result.Model);

            Assert.Null(model.Num1);
            Assert.Null(model.Num2);
            Assert.Null(model.Result);
            Assert.Null(model.Error);
        }

        [Fact]
        public void CalculateMmc_InvalidModelState_ReturnsViewWithoutCallingService()
        {
            _controller.ModelState.AddModelError("Num1", "Required");
            var vm = new MmcViewModel { Num2 = 6 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateMmc(vm));

            Assert.Equal("Index", result.ViewName);
            Assert.Same(vm, result.Model);
            _mmcService.DidNotReceive().Mmc(Arg.Any<int>(), Arg.Any<int>());
        }

        [Fact]
        public void CalculateMmc_ValidInput_SetsResultFromService()
        {
            _mmcService.Mmc(4, 6).Returns(12);
            var vm = new MmcViewModel { Num1 = 4, Num2 = 6 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateMmc(vm));
            var model = Assert.IsType<MmcViewModel>(result.Model);

            Assert.Equal(12, model.Result);
            Assert.Null(model.Error);
        }

        [Fact]
        public void CalculateMmc_ServiceThrows_SetsErrorAndKeepsResultNull()
        {
            _mmcService.Mmc(Arg.Any<int>(), Arg.Any<int>())
                .Returns(_ => throw new Exception("Entrada inválida!"));
            var vm = new MmcViewModel { Num1 = -1, Num2 = 6 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateMmc(vm));
            var model = Assert.IsType<MmcViewModel>(result.Model);

            Assert.Equal("Entrada inválida!", model.Error);
            Assert.Null(model.Result);
        }
    }
}
