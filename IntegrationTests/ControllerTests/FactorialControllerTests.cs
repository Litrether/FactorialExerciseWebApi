using Microsoft.AspNetCore.Mvc;
using System.Net;
using Xunit;

namespace IntegrationTests.ControllerTests
{
    public class FactorialControllerTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(5, 120)]
        [InlineData(10, 3628800)]
        [InlineData(7, 5040)]
        [InlineData(20, 2432902008176640000)]
        public async void GetFactorialReturnValidFact(long n, long excepted)
        {
            var response = await TestFixture.Client.GetAsync($"factorials/{n}");
            response.EnsureSuccessStatusCode();

            var fact = long.Parse(await response.Content.ReadAsStringAsync());

            Assert.Equal(excepted, fact);
        }

        [Fact]
        public async void GetFactorialReturnBadRequestWhenValueIsNegative()
        {
            var n = -10;
            var response = await TestFixture.Client.GetAsync($"factorials/{n}");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData(4, "{null, 5}")]
        [InlineData(6, "{5, 7}")]
        [InlineData(400, "{7, null}")]
        public async void GetNearestValueReturnValidValueRange(long n, string excepted)
        {
            var responseAdd5 = await TestFixture.Client.GetAsync($"factorials/5");
            responseAdd5.EnsureSuccessStatusCode();
            var responseAdd7 = await TestFixture.Client.GetAsync($"factorials/7");
            responseAdd7.EnsureSuccessStatusCode();

            var response = await TestFixture.Client.GetAsync($"factorials/{n}/nearest-value");
            var result = await response.Content.ReadAsStringAsync(); 

            Assert.Equal(excepted, result);
        }

        [Theory]
        [InlineData(1, "{null, 5}")]
        [InlineData(400, "{5, 7}")]
        [InlineData(9223372036854775807, "{7, null}")]
        public async void GetNearestFactorialReturnValidValueRange(long x, string excepted)
        {
            var responseAdd5 = await TestFixture.Client.GetAsync($"factorials/5");
            responseAdd5.EnsureSuccessStatusCode();
            var responseAdd7 = await TestFixture.Client.GetAsync($"factorials/7");
            responseAdd7.EnsureSuccessStatusCode();

            var response = await TestFixture.Client.GetAsync($"values/{x}/nearest-factorial");
            var result = await response.Content.ReadAsStringAsync(); 

            Assert.Equal(excepted, result);
        }
    }
}
