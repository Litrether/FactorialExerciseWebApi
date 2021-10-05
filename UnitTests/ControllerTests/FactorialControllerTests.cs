using FactorialExerciseWebApi.Controllers;
using FactorialExerciseWebApi.Entities;
using FactorialExerciseWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace UnitTests.ControllerTests
{
    public class FactorialControllerTests
    {
        Mock<IFactorialService> _factService = new Mock<IFactorialService>();
        Mock<IRepository> _repository = new Mock<IRepository>();
        private readonly FactorialController _controller;

        public FactorialControllerTests()
        {
            _controller = new FactorialController(_repository.Object, _factService.Object);
        }

        [Fact]
        public async void GetFactorialReturnsOkResult()
        {
            var n = 1;
            var result = await _controller.GetFactorial(n);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetFactorialReturnsBadRequestWhenValueIsNegative()
        {
            var n = -1;
            var result = await _controller.GetFactorial(n);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void GetNearestValueReturnsOkResult()
        {
            var n = 1;
            var result = await _controller.GetNearestValue(n);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetNearestValueReturnsBadRequestWhenValueIsNegative()
        {
            var n = -1;
            var result = await _controller.GetNearestValue(n);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async void GetNearestFactorialReturnsOkResult()
        {
            var n = 1;
            var result = await _controller.GetNearestFactorial(n);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetNearestFactorialReturnsBadRequestWhenValueIsNegative()
        {
            var n = -1;
            var result = await _controller.GetNearestFactorial(n);
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
