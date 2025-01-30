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
            var Controllers = CreateController();

            //Act
            //執行要測試的函式
            var Results = Controllers.Get();

            //Assert
            //確認結果不為null
            Assert.NotNull(Results);

            //確認結果數量等於5
            Assert.Equal(5, Results.Count());
        }
        [Theory]
        [InlineData("Cool", "Cool")]
        [InlineData("Scorching", "Scorching")]
        [InlineData("Hot", "Hot")]
        public void Get_Name(string name, string expectedSummary)
        {
            //Arrange
            var Controllers = CreateController();

            //Act
            //執行要測試的函式
            var Results = Controllers.GetByName(name);

            //Assert
            //確認結果不為null
            Assert.NotNull(Results);
            Assert.Equal(expectedSummary , Results.Summary);
        }

        [Fact]
        public void Get_Name_NotFound()
        {
            //Arrange
            var Controllers = CreateController();

            //Act
            //執行要測試的函式
            var Results = Controllers.GetByName("test");

            //Assert
            //確認結果為null
            Assert.Null(Results);
        }
    }
}
