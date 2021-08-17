using Xunit;

namespace Demo.Tests
{
    public class AssertNumbersTest
    {
        [Fact]
        public void Calculator_Sum_MustBeEqual()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            double result = calculator.Sum(1, 2);

            //Assert
            Assert.Equal(3, result);
        }    
        
        [Fact]
        public void Calculator_Sum_MustNotBeEqual()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            double result = calculator.Sum(1.3212231, 2.312312);

            //Assert
            Assert.NotEqual(3.3, result, 1);
        }
    }
}
