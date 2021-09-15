using Features.Employees;
using MediatR;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(EmployeeAutoMockerCollection))]
    public class EmployeeServiceAutoMockerFixtureTests
    {
        readonly EmployeeTestsAutoMockerFixture _employeeTestsAutoMockerFixture;
        private readonly EmployeeService _employeeService;

        public EmployeeServiceAutoMockerFixtureTests(EmployeeTestsAutoMockerFixture employeeBogusTestsFixture)
        {
            _employeeTestsAutoMockerFixture = employeeBogusTestsFixture;
            _employeeService = _employeeTestsAutoMockerFixture.GetEmployeeService();

        }

        [Fact(DisplayName = "Add Employee with Success")]
        [Trait("Category", "Employee Service AutoMockFixture Tests")]
        public void EmployeeService_Add_MustExecuteWithSuccess()
        {
            // Arrange
            Employee employee = _employeeTestsAutoMockerFixture.CreateValidEmployee();

            // Act
            _employeeService.Add(employee);

            // Assert
            _employeeTestsAutoMockerFixture.Mocker.GetMock<IEmployeeRepository>().Verify(r => r.Add(employee), Times.Once);
            _employeeTestsAutoMockerFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None),
                           Times.Once);

        }

        [Fact(DisplayName = "Add Employee with Failure")]
        [Trait("Category", "Employee Service AutoMockFixture Tests")]
        public void EmployeeService_Add_MustFailDueToInvalidEmployee()
        {
            // Arrange
            Employee employee = _employeeTestsAutoMockerFixture.CreateInvalidEmployee();

            // Act
            _employeeService.Add(employee);

            // Assert
            _employeeTestsAutoMockerFixture.Mocker.GetMock<IEmployeeRepository>().Verify(r => r.Add(employee), Times.Never);
            _employeeTestsAutoMockerFixture.Mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None),
                           Times.Never);
        }

        [Fact(DisplayName = "Get Active Employees")]
        [Trait("Category", "Employee Service AutoMockFixture Tests")]
        public void EmployeeService_GetAllActive_MustReturnOnlyActiveEmployees()
        {
            // Arrange
            _employeeTestsAutoMockerFixture.Mocker.GetMock<IEmployeeRepository>()
                .Setup(e => e.GetAll())
                .Returns(_employeeTestsAutoMockerFixture.CreateVariedEmployees());


            // Act
            IEnumerable<Employee> employees = _employeeService.GetAllActive();

            // Assert
            _employeeTestsAutoMockerFixture.Mocker.GetMock<IEmployeeRepository>().Verify(r => r.GetAll(), Times.Once);
            Assert.True(employees.Any());
            Assert.False(employees.Count(e => !e.Active) > 0);
        }
    }
}
