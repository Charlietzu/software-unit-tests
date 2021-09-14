using Features.Employees;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(EmployeeCollection))]
    public class InvalidEmployeeTest
    {
        private readonly EmployeeTestsFixture _employeeTestsFixture;

        public InvalidEmployeeTest(EmployeeTestsFixture employeeTestsFixture)
        {
            _employeeTestsFixture = employeeTestsFixture;
        }

        [Fact(DisplayName = "New Invalid Employee")]
        [Trait("Category", "Employee Fixture Testing")]
        public void Employee_NewEmployee_MustBeInvalid()
        {
            // Arrange
            Employee employee = _employeeTestsFixture.CreateInvalidEmployee();

            // Act
            bool result = employee.IsValid();

            // Assert
            Assert.False(result);
            Assert.NotEmpty(employee.ValidationResult.Errors);
        }
    }
}
