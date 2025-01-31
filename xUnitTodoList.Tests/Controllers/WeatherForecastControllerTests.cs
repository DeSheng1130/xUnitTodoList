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
            Assert.NotNull(results);

            //確認結果數量等於5
            Assert.Equal(5, results.Count());
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
            Assert.NotNull(results);
            Assert.Equal(expectedSummary, results.Summary);
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
            Assert.Null(results);
        }
    }
}
