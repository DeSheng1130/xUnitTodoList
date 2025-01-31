using Xunit;

namespace xUnitTodoList.Tests
{
    public class CalculatorTests
    {
        //告訴編譯器要執行的測試方法
        [Theory]
        [InlineData(5, 15, 20)]
        [InlineData(35, 45, 80)]
        [InlineData(-29, 3, -26)]
        public void Add_(int num1, int num2, int expected)
        {
            //Act
            var actual = Calculator.Add(num1, num2);
            //Assert
            Should.BeEqualTo(actual,expected);
        }

        [Theory]
        [InlineData(5, 15, -10)]
        [InlineData(35, 45, -10)]
        [InlineData(-29, 3, -32)]
        public void Subtraction_(int num1, int num2, int expected)
        {
            var actual = Calculator.Subtraction(num1, num2);
            Should.BeEqualTo(actual,expected);
        }

        [Theory]
        [InlineData(5, 15, 75)]
        [InlineData(100, -10, -1000)]
        [InlineData(-30, -3, 90)]
        public void Multiplication_(int num1, int num2, int expected)
        {
            var actual = Calculator.Multiplication(num1, num2);
            Should.BeEqualTo(actual,expected);
        }

        [Theory]
        [InlineData(15, 5, 3)]
        [InlineData(100, -10, -10)]
        [InlineData(-30, -3, 10)]
        public void Division_(int num1, int num2, int expected)
        {
            var actual = Calculator.Division(num1, num2);
            Should.BeEqualTo(actual,expected);
        }

    }
}
