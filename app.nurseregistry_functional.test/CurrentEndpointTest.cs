using Alba;
using app.nurseregistry_functional.test.Factory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace app.nurseregistry_functional.test
{
    public class CurrentEndpointTest : IClassFixture<AppFactory>
    {
        private readonly IAlbaHost host;
        public CurrentEndpointTest(AppFactory app)
        {
            host = app.AlbaHost;
        }

        [Fact]
        public async Task current_date()
        {
            //arrange

            //act
            await host.Scenario(scenario =>
            {
                scenario.Get.Url("/greeting");
                scenario.ContentShouldBe("Hello World!");
            });

            //assert
            host.BeforeEach(httpContext =>
            {
                System.Console.WriteLine(httpContext.Request.Path);
            })
            .AfterEach(httpContext =>
            {
                // do any kind of cleanup after each scenario completes
                System.Console.WriteLine(httpContext!.Response!.ContentLength);
            });
        }
    }
}