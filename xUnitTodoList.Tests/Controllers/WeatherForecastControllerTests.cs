using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using xUnitTodoList.Controllers;

namespace xUnitTodoList.Tests.Controllers
{
    public class WeatherForecastControllerTests
    {
        private static WeatherForecastController CreateController()
        {
            var mockLogger = new Mock<ILogger<WeatherForecastController>>();
            return new WeatherForecastController(mockLogger.Object);
        }

        [Fact]
        public void Get_()
        {
            //Arrange
            var controllers = CreateController();

            //Act
            //執行要測試的函式
            var results = controllers.Get();

            //Assert
            //確認結果不為null
            Should.BeNotNull(results);

            //確認結果數量等於5
            Should.HaveCountOf(results, 5);
        }
        [Theory]
        [InlineData("Cool", "Cool")]
        [InlineData("Scorching", "Scorching")]
        [InlineData("Hot", "Hot")]
        public void Get_Name(string name, string expectedSummary)
        {
            //Arrange
            var controllers = CreateController();

            //Act
            //執行要測試的函式
            var results = controllers.GetByName(name);

            //Assert
            //確認結果不為null
            Should.BeNotNull(results);
            Should.BeEqualTo(results?.Summary, expectedSummary);
        }

        [Fact]
        public void Get_Name_NotFound()
        {
            //Arrange
            var controllers = CreateController();

            //Act
            //執行要測試的函式
            var results = controllers.GetByName("test");

            //Assert
            //確認結果為null
            Should.BeNull(results);
        }

        [Theory]
        [InlineData("Cool", "Cool")]
        [InlineData("Scorching", "Scorching")]
        [InlineData("Hot", "Hot")]
        public async Task GetByName_ShouldReturnCorrectSummary_AfterHighConcurrencyTest(string name, string expectedSummary)
        {
            //Arrange
            var controller = CreateController();

            // 模擬高併發，並行發送 1000 次請求
            var tasks = Enumerable.Range(0, 1000)
                .Select(_ => Task.Run(() => controller.GetByName(name)))
                .ToArray();

            //Act
            var results = await Task.WhenAll(tasks);

            //Assert
            // 確保每個結果都不為 null 且結果與預期一致
            foreach (var result in results)
            {
                Should.BeNotNull(result);
                Should.BeEqualTo(result?.Summary, expectedSummary);
            }
        }
    }
}
