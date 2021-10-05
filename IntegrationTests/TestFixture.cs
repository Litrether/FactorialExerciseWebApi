using FactorialExerciseWebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Http;

namespace IntegrationTests
{
    public static class TestFixture
    {
        public static TestServer TestServer { get; }
        public static HttpClient Client { get; }

        static TestFixture()
        {
            var webBuilder = new WebHostBuilder()
                .UseStartup<Startup>();

            TestServer = new TestServer(webBuilder);
            Client = TestServer.CreateClient();

        }

        public static void Dispose()
        {
            Client.Dispose();
            TestServer.Dispose();
        }
    }
}
