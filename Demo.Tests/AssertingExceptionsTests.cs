using System;
using Xunit;

namespace Demo.Tests
{
    public class AssertingExceptionsTests
    {
        [Fact]
        public void Calculator_Divide_MustReturnErrorDivideByZero()
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act & Assert
            Assert.Throws<DivideByZeroException>(() => calc.Divide(10, 0));
        }        
        
        [Fact]
        public void Employee_Salary_MustReturnErrorSalaryLowerThanAllowed()
        {
            //Arrange & Act & Assert
            Exception ex = Assert.Throws<Exception>(() => EmployeFactory.Create("Caio", 250));

            Assert.Equal("Salary lower than the allowed", ex.Message);
        }
    }
}
