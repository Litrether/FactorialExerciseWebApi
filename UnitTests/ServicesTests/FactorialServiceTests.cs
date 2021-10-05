using FactorialExerciseWebApi.Services;
using Xunit;

namespace UnitTests
{
    public class FactorialServiceTests
    {
        private readonly FactorialService _factService;

        public FactorialServiceTests()
        {
            _factService = new FactorialService();
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(5, 120)]
        [InlineData(10, 3628800)]
        [InlineData(7, 5040)]
        [InlineData(20, 2432902008176640000)]
        public void FactReturnsValidFactorial(long n, long excepted)
        {
            var result = _factService.Fact(n);
            Assert.Equal(excepted, result);
        }
    }
}
