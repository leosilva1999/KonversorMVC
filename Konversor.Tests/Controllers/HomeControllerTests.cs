using Konversor.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace Konversor.Tests.Controllers
{
    public class HomeControllerTests
    {
        private readonly HomeController _controller = new(NullLogger<HomeController>.Instance);

        [Fact]
        public void Index_ReturnsView()
        {
            Assert.IsType<ViewResult>(_controller.Index());
        }

        [Fact]
        public void Privacy_ReturnsView()
        {
            Assert.IsType<ViewResult>(_controller.Privacy());
        }
    }
}
