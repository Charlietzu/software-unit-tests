using Features.Employees;
using System;
using Xunit;

namespace Features.Tests
{
    public class EmployeeTests
    {
        [Fact(DisplayName = "New Valid Employee")]
        [Trait("Category", "Employee Trait Testing")]
        public void Employee_NewEmployee_MustBeValid()
        {
            // Arrange
            Employee employee = new Employee(
                Guid.NewGuid(),
                "Caio",
                "César",
                DateTime.Now.AddYears(-30),
                DateTime.Now,
                "caio@gmail.com",
                true
                );

            // Act
            bool result = employee.IsValid();

            // Assert
            Assert.True(result);
            Assert.Empty(employee.ValidationResult.Errors);
        }

        [Fact(DisplayName = "New Invalid Employee")]
        [Trait("Category", "Employee Trait Testing")]
        public void Employee_NewEmployee_MustBeInvalid()
        {
            // Arrange
            Employee employee = new Employee(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                DateTime.Now,
                "caio@gmail.com",
                true
                );

            // Act
            bool result = employee.IsValid();

            // Assert
            Assert.False(result);
            Assert.NotEmpty(employee.ValidationResult.Errors);
        }
    }
}
