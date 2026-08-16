using Konversor.Controllers;
using Konversor.Services;
using Konversor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Konversor.Tests.Controllers
{
    public class MdcControllerTests
    {
        private readonly IMdcService _mdcService = Substitute.For<IMdcService>();
        private readonly MdcController _controller;

        public MdcControllerTests()
        {
            _controller = new MdcController(_mdcService);
        }

        [Fact]
        public void Index_Get_ReturnsViewWithEmptyViewModel()
        {
            var result = Assert.IsType<ViewResult>(_controller.Index());
            var model = Assert.IsType<MdcViewModel>(result.Model);

            Assert.Null(model.Num1);
            Assert.Null(model.Num2);
            Assert.Null(model.Result);
            Assert.Null(model.Error);
        }

        [Fact]
        public void CalculateMdc_InvalidModelState_ReturnsViewWithoutCallingService()
        {
            _controller.ModelState.AddModelError("Num1", "Required");
            var vm = new MdcViewModel { Num2 = 18 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateMdc(vm));

            Assert.Equal("Index", result.ViewName);
            Assert.Same(vm, result.Model);
            _mdcService.DidNotReceive().Mdc(Arg.Any<int>(), Arg.Any<int>());
        }

        [Fact]
        public void CalculateMdc_ValidInput_SetsResultFromService()
        {
            _mdcService.Mdc(48, 18).Returns(6);
            var vm = new MdcViewModel { Num1 = 48, Num2 = 18 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateMdc(vm));
            var model = Assert.IsType<MdcViewModel>(result.Model);

            Assert.Equal(6, model.Result);
            Assert.Null(model.Error);
        }

        [Fact]
        public void CalculateMdc_ServiceThrows_SetsErrorAndKeepsResultNull()
        {
            _mdcService.Mdc(Arg.Any<int>(), Arg.Any<int>())
                .Returns(_ => throw new Exception("Entrada inválida!"));
            var vm = new MdcViewModel { Num1 = -1, Num2 = 18 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateMdc(vm));
            var model = Assert.IsType<MdcViewModel>(result.Model);

            Assert.Equal("Entrada inválida!", model.Error);
            Assert.Null(model.Result);
        }
    }
}
