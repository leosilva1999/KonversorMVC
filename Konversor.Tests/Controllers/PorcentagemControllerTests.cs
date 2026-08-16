using Konversor.Controllers;
using Konversor.Services;
using Konversor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Konversor.Tests.Controllers
{
    public class PorcentagemControllerTests
    {
        private const string InvalidInputMessage = "Entrada inválida!";

        private readonly IPorcentagemService _porcentagemService = Substitute.For<IPorcentagemService>();
        private readonly PorcentagemController _controller;

        public PorcentagemControllerTests()
        {
            _controller = new PorcentagemController(_porcentagemService);
        }

        [Fact]
        public void Index_Get_ReturnsViewWithPageViewModel()
        {
            var result = Assert.IsType<ViewResult>(_controller.Index());

            Assert.IsType<PorcentagemPageViewModel>(result.Model);
        }

        // CalculatePercentOf

        [Fact]
        public void CalculatePercentOf_InvalidModelState_ReturnsViewWithoutCallingService()
        {
            _controller.ModelState.AddModelError("Value", "Required");
            var vm = new PercentOfViewModel { Percentage = 10 };

            var result = Assert.IsType<ViewResult>(_controller.CalculatePercentOf(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal("Index", result.ViewName);
            Assert.Same(vm, pageVm.PercentOf);
            _porcentagemService.DidNotReceive().PercentOf(Arg.Any<double>(), Arg.Any<double>());
        }

        [Fact]
        public void CalculatePercentOf_ValidInput_SetsResultOnPageViewModel()
        {
            _porcentagemService.PercentOf(200, 10).Returns(20);
            var vm = new PercentOfViewModel { Value = 200, Percentage = 10 };

            var result = Assert.IsType<ViewResult>(_controller.CalculatePercentOf(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal(20, pageVm.PercentOf.Result);
            Assert.Null(pageVm.PercentOf.Error);
        }

        [Fact]
        public void CalculatePercentOf_ServiceThrows_SetsErrorOnPageViewModel()
        {
            _porcentagemService.PercentOf(Arg.Any<double>(), Arg.Any<double>())
                .Returns(_ => throw new Exception(InvalidInputMessage));
            var vm = new PercentOfViewModel { Value = -1, Percentage = 10 };

            var result = Assert.IsType<ViewResult>(_controller.CalculatePercentOf(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal(InvalidInputMessage, pageVm.PercentOf.Error);
            Assert.Null(pageVm.PercentOf.Result);
        }

        // CalculateNum1IsPercentOfNum2

        [Fact]
        public void CalculateNum1IsPercentOfNum2_InvalidModelState_ReturnsViewWithoutCallingService()
        {
            _controller.ModelState.AddModelError("Num1", "Required");
            var vm = new Num1IsPercentOfNum2ViewModel { Num2 = 10 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateNum1IsPercentOfNum2(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal("Index", result.ViewName);
            Assert.Same(vm, pageVm.Num1IsPercentOfNum2);
            _porcentagemService.DidNotReceive().Num1IsPercentOfNum2(Arg.Any<double>(), Arg.Any<double>());
        }

        [Fact]
        public void CalculateNum1IsPercentOfNum2_ValidInput_SetsResultOnPageViewModel()
        {
            _porcentagemService.Num1IsPercentOfNum2(50, 200).Returns(25);
            var vm = new Num1IsPercentOfNum2ViewModel { Num1 = 50, Num2 = 200 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateNum1IsPercentOfNum2(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal(25, pageVm.Num1IsPercentOfNum2.Result);
            Assert.Null(pageVm.Num1IsPercentOfNum2.Error);
        }

        [Fact]
        public void CalculateNum1IsPercentOfNum2_ServiceThrows_SetsErrorOnPageViewModel()
        {
            _porcentagemService.Num1IsPercentOfNum2(Arg.Any<double>(), Arg.Any<double>())
                .Returns(_ => throw new Exception(InvalidInputMessage));
            var vm = new Num1IsPercentOfNum2ViewModel { Num1 = 20, Num2 = 10 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateNum1IsPercentOfNum2(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal(InvalidInputMessage, pageVm.Num1IsPercentOfNum2.Error);
            Assert.Null(pageVm.Num1IsPercentOfNum2.Result);
        }

        // CalculateIncreasePercentOf

        [Fact]
        public void CalculateIncreasePercentOf_InvalidModelState_ReturnsViewWithoutCallingService()
        {
            _controller.ModelState.AddModelError("IncreaseInitialValue", "Required");
            var vm = new IncreasePercentageViewModel { IncreaseFinalValue = 150 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateIncreasePercentOf(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal("Index", result.ViewName);
            Assert.Same(vm, pageVm.IncreasePercentage);
            _porcentagemService.DidNotReceive().IncreasePercentage(Arg.Any<double>(), Arg.Any<double>());
        }

        [Fact]
        public void CalculateIncreasePercentOf_ValidInput_SetsResultOnPageViewModel()
        {
            _porcentagemService.IncreasePercentage(100, 150).Returns(50);
            var vm = new IncreasePercentageViewModel { IncreaseInitialValue = 100, IncreaseFinalValue = 150 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateIncreasePercentOf(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal(50, pageVm.IncreasePercentage.Result);
            Assert.Null(pageVm.IncreasePercentage.Error);
        }

        [Fact]
        public void CalculateIncreasePercentOf_ServiceThrows_SetsErrorOnPageViewModel()
        {
            _porcentagemService.IncreasePercentage(Arg.Any<double>(), Arg.Any<double>())
                .Returns(_ => throw new Exception(InvalidInputMessage));
            var vm = new IncreasePercentageViewModel { IncreaseInitialValue = 150, IncreaseFinalValue = 100 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateIncreasePercentOf(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal(InvalidInputMessage, pageVm.IncreasePercentage.Error);
            Assert.Null(pageVm.IncreasePercentage.Result);
        }

        // CalculateDecreasePercentOf

        [Fact]
        public void CalculateDecreasePercentOf_InvalidModelState_ReturnsViewWithoutCallingService()
        {
            _controller.ModelState.AddModelError("DecreaseInitialValue", "Required");
            var vm = new DecreasePercentageViewModel { DecreaseFinalValue = 50 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateDecreasePercentOf(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal("Index", result.ViewName);
            Assert.Same(vm, pageVm.DecreasePercentage);
            _porcentagemService.DidNotReceive().DecreasePercentage(Arg.Any<double>(), Arg.Any<double>());
        }

        [Fact]
        public void CalculateDecreasePercentOf_ValidInput_SetsResultOnPageViewModel()
        {
            _porcentagemService.DecreasePercentage(100, 60).Returns(-40);
            var vm = new DecreasePercentageViewModel { DecreaseInitialValue = 100, DecreaseFinalValue = 60 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateDecreasePercentOf(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal(-40, pageVm.DecreasePercentage.Result);
            Assert.Null(pageVm.DecreasePercentage.Error);
        }

        [Fact]
        public void CalculateDecreasePercentOf_ServiceThrows_SetsErrorOnPageViewModel()
        {
            _porcentagemService.DecreasePercentage(Arg.Any<double>(), Arg.Any<double>())
                .Returns(_ => throw new Exception(InvalidInputMessage));
            var vm = new DecreasePercentageViewModel { DecreaseInitialValue = 50, DecreaseFinalValue = 100 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateDecreasePercentOf(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal(InvalidInputMessage, pageVm.DecreasePercentage.Error);
            Assert.Null(pageVm.DecreasePercentage.Result);
        }

        // CalculatePercentOfXOverY

        [Fact]
        public void CalculatePercentOfXOverY_InvalidModelState_ReturnsViewWithoutCallingService()
        {
            _controller.ModelState.AddModelError("ValueX", "Required");
            var vm = new PercentOfXOverYViewModel { ValueY = 100 };

            var result = Assert.IsType<ViewResult>(_controller.CalculatePercentOfXOverY(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal("Index", result.ViewName);
            Assert.Same(vm, pageVm.PercentOfXOverY);
            _porcentagemService.DidNotReceive().PercentOfXOverY(Arg.Any<double>(), Arg.Any<double>());
        }

        [Fact]
        public void CalculatePercentOfXOverY_ValidInput_SetsResultOnPageViewModel()
        {
            _porcentagemService.PercentOfXOverY(25, 100).Returns(25);
            var vm = new PercentOfXOverYViewModel { ValueX = 25, ValueY = 100 };

            var result = Assert.IsType<ViewResult>(_controller.CalculatePercentOfXOverY(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal(25, pageVm.PercentOfXOverY.Result);
            Assert.Null(pageVm.PercentOfXOverY.Error);
        }

        [Fact]
        public void CalculatePercentOfXOverY_ServiceThrows_SetsErrorOnPageViewModel()
        {
            _porcentagemService.PercentOfXOverY(Arg.Any<double>(), Arg.Any<double>())
                .Returns(_ => throw new Exception(InvalidInputMessage));
            var vm = new PercentOfXOverYViewModel { ValueX = 20, ValueY = 10 };

            var result = Assert.IsType<ViewResult>(_controller.CalculatePercentOfXOverY(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal(InvalidInputMessage, pageVm.PercentOfXOverY.Error);
            Assert.Null(pageVm.PercentOfXOverY.Result);
        }

        // CalculateIncreasePercentageOnValue

        [Fact]
        public void CalculateIncreasePercentageOnValue_InvalidModelState_ReturnsViewWithoutCallingService()
        {
            _controller.ModelState.AddModelError("ValueToIncrease", "Required");
            var vm = new IncreasePercentageOnValueViewModel { IncreasePercentage = 10 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateIncreasePercentageOnValue(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal("Index", result.ViewName);
            Assert.Same(vm, pageVm.IncreasePercentageOnValue);
            _porcentagemService.DidNotReceive().IncreasePercentageOnValue(Arg.Any<double>(), Arg.Any<double>());
        }

        [Fact]
        public void CalculateIncreasePercentageOnValue_ValidInput_SetsResultOnPageViewModel()
        {
            _porcentagemService.IncreasePercentageOnValue(100, 10).Returns(110);
            var vm = new IncreasePercentageOnValueViewModel { ValueToIncrease = 100, IncreasePercentage = 10 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateIncreasePercentageOnValue(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal(110, pageVm.IncreasePercentageOnValue.Result);
            Assert.Null(pageVm.IncreasePercentageOnValue.Error);
        }

        [Fact]
        public void CalculateIncreasePercentageOnValue_ServiceThrows_SetsErrorOnPageViewModel()
        {
            _porcentagemService.IncreasePercentageOnValue(Arg.Any<double>(), Arg.Any<double>())
                .Returns(_ => throw new Exception(InvalidInputMessage));
            var vm = new IncreasePercentageOnValueViewModel { ValueToIncrease = -1, IncreasePercentage = 10 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateIncreasePercentageOnValue(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal(InvalidInputMessage, pageVm.IncreasePercentageOnValue.Error);
            Assert.Null(pageVm.IncreasePercentageOnValue.Result);
        }

        // CalculateDecreasePercentageOnValue

        [Fact]
        public void CalculateDecreasePercentageOnValue_InvalidModelState_ReturnsViewWithoutCallingService()
        {
            _controller.ModelState.AddModelError("ValueToDecrease", "Required");
            var vm = new DecreasePercentageOnValueViewModel { DecreasePercentage = 10 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateDecreasePercentageOnValue(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal("Index", result.ViewName);
            Assert.Same(vm, pageVm.DecreasePercentageOnValue);
            _porcentagemService.DidNotReceive().DecreasePercentageOnValue(Arg.Any<double>(), Arg.Any<double>());
        }

        [Fact]
        public void CalculateDecreasePercentageOnValue_ValidInput_SetsResultOnPageViewModel()
        {
            _porcentagemService.DecreasePercentageOnValue(100, 10).Returns(90);
            var vm = new DecreasePercentageOnValueViewModel { ValueToDecrease = 100, DecreasePercentage = 10 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateDecreasePercentageOnValue(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal(90, pageVm.DecreasePercentageOnValue.Result);
            Assert.Null(pageVm.DecreasePercentageOnValue.Error);
        }

        [Fact]
        public void CalculateDecreasePercentageOnValue_ServiceThrows_SetsErrorOnPageViewModel()
        {
            _porcentagemService.DecreasePercentageOnValue(Arg.Any<double>(), Arg.Any<double>())
                .Returns(_ => throw new Exception(InvalidInputMessage));
            var vm = new DecreasePercentageOnValueViewModel { ValueToDecrease = -1, DecreasePercentage = 10 };

            var result = Assert.IsType<ViewResult>(_controller.CalculateDecreasePercentageOnValue(vm));
            var pageVm = Assert.IsType<PorcentagemPageViewModel>(result.Model);

            Assert.Equal(InvalidInputMessage, pageVm.DecreasePercentageOnValue.Error);
            Assert.Null(pageVm.DecreasePercentageOnValue.Result);
        }
    }
}
