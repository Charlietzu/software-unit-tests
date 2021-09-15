using Features.Employees;
using MediatR;
using Moq;
using Moq.AutoMock;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(EmployeeBogusCollection))]
    public class EmployeeServiceAutoMockerTests
    {
        readonly EmployeeBogusTestsFixture _employeeBogusTestsFixture;

        public EmployeeServiceAutoMockerTests(EmployeeBogusTestsFixture employeeBogusTestsFixture)
        {
            _employeeBogusTestsFixture = employeeBogusTestsFixture;
        }

        [Fact(DisplayName = "Add Employee with Success")]
        [Trait("Category", "Employee Service AutoMock Tests")]
        public void EmployeeService_Add_MustExecuteWithSuccess()
        {
            // Arrange
            Employee employee = _employeeBogusTestsFixture.CreateValidEmployee();
            AutoMocker mocker = new AutoMocker();
            EmployeeService employeeService = mocker.CreateInstance<EmployeeService>();

            // Act
            employeeService.Add(employee);

            // Assert
            mocker.GetMock<IEmployeeRepository>().Verify(r => r.Add(employee), Times.Once);
            mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None),
                           Times.Once);

        }

        [Fact(DisplayName = "Add Employee with Failure")]
        [Trait("Category", "Employee Service AutoMock Tests")]
        public void EmployeeService_Add_MustFailDueToInvalidEmployee()
        {
            // Arrange
            Employee employee = _employeeBogusTestsFixture.CreateInvalidEmployee();
            AutoMocker mocker = new AutoMocker();
            EmployeeService employeeService = mocker.CreateInstance<EmployeeService>();

            // Act
            employeeService.Add(employee);

            // Assert
            mocker.GetMock<IEmployeeRepository>().Verify(r => r.Add(employee), Times.Never);
            mocker.GetMock<IMediator>().Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None),
                           Times.Never);
        }

        [Fact(DisplayName = "Get Active Employees")]
        [Trait("Category", "Employee Service AutoMock Tests")]
        public void EmployeeService_GetAllActive_MustReturnOnlyActiveEmployees()
        {
            // Arrange
            AutoMocker mocker = new AutoMocker();
            EmployeeService employeeService = mocker.CreateInstance<EmployeeService>();

            mocker.GetMock<IEmployeeRepository>()
                .Setup(e => e.GetAll())
                .Returns(_employeeBogusTestsFixture.CreateVariedEmployees());


            // Act
            IEnumerable<Employee> employees = employeeService.GetAllActive();

            // Assert
            mocker.GetMock<IEmployeeRepository>().Verify(r => r.GetAll(), Times.Once);
            Assert.True(employees.Any());
            Assert.False(employees.Count(e => !e.Active) > 0);
        }
    }
}
