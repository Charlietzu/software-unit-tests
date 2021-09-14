using Features.Employees;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(EmployeeCollection))]
    public class ValidEmployeeTest
    {
        private readonly EmployeeTestsFixture _employeeTestsFixture;

        public ValidEmployeeTest(EmployeeTestsFixture employeeTestsFixture)
        {
            _employeeTestsFixture = employeeTestsFixture;
        }

        [Fact(DisplayName = "New Valid Employee")]
        [Trait("Category", "Employee Fixture Testing")]
        public void Employee_NewEmployee_MustBeValid()
        {
            // Arrange
            Employee employee = _employeeTestsFixture.CreateValidEmployee();

            // Act
            bool result = employee.IsValid();

            // Assert
            Assert.True(result);
            Assert.Empty(employee.ValidationResult.Errors);
        }
    }
}
