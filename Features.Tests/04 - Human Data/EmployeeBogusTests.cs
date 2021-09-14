using Features.Employees;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(EmployeeBogusCollection))]
    public class EmployeeBogusTests
    {
        private readonly EmployeeBogusTestsFixture _employeeTestsFixture;

        public EmployeeBogusTests(EmployeeBogusTestsFixture employeeTestsFixture)
        {
            _employeeTestsFixture = employeeTestsFixture;
        }

        [Fact(DisplayName = "New Valid Employee")]
        [Trait("Category", "Employee Bogus Tests")]
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

        [Fact(DisplayName = "New Employee Invalid")]
        [Trait("Category", "Employee Bogus Tests")]
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
