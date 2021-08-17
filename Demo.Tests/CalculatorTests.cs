using Xunit;

namespace Demo.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_Sum_ReturnSumValue()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            double result = calculator.Sum(2, 2);

            //Assert
            Assert.Equal(4, result);
        }

        [Theory]
        [InlineData(1,1,2)]
        [InlineData(4,2,6)]
        [InlineData(7,3,10)]
        [InlineData(6,6,12)]
        [InlineData(9,9,18)]
        public void Calculator_Sum_ReturnCorrectSumValues(double v1, double v2, double total)
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            double result = calculator.Sum(v1, v2);

            //Assert
            Assert.Equal(total, result);
        }
    }
}
