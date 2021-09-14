using Features.Employees;
using MediatR;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(EmployeeBogusCollection))]
    public class EmployeeServiceTests
    {
        readonly EmployeeBogusTestsFixture _employeeBogusTestsFixture;

        public EmployeeServiceTests(EmployeeBogusTestsFixture employeeBogusTestsFixture)
        {
            _employeeBogusTestsFixture = employeeBogusTestsFixture;
        }


        [Fact(DisplayName = "Add Employee with Success")]
        [Trait("Category", "Employee Service Mock Tests")]
        public void EmployeeService_Add_MustExecuteWithSuccess()
        {
            // Arrange
            Employee employee = _employeeBogusTestsFixture.CreateValidEmployee();
            Mock<IEmployeeRepository> employeeRepo = new Mock<IEmployeeRepository>();
            Mock<IMediator> mediatr = new Mock<IMediator>();

            EmployeeService employeeService = new EmployeeService(employeeRepo.Object, mediatr.Object);

            // Act
            employeeService.Add(employee);

            // Assert
            employeeRepo.Verify(r => r.Add(employee), Times.Once);
            mediatr.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None),
                           Times.Once);
        }

        [Fact(DisplayName = "Add Employee with Failure")]
        [Trait("Category", "Employee Service Mock Tests")]
        public void EmployeeService_Add_MustFailDueToInvalidEmployee()
        {
            // Arrange
            Employee employee = _employeeBogusTestsFixture.CreateInvalidEmployee();
            Mock<IEmployeeRepository> employeeRepo = new Mock<IEmployeeRepository>();
            Mock<IMediator> mediatr = new Mock<IMediator>();

            EmployeeService employeeService = new EmployeeService(employeeRepo.Object, mediatr.Object);

            // Act
            employeeService.Add(employee);

            // Assert
            employeeRepo.Verify(r => r.Add(employee), Times.Never);
            mediatr.Verify(m => m.Publish(It.IsAny<INotification>(), CancellationToken.None),
                           Times.Never);
        }

        [Fact(DisplayName = "Get Active Employees")]
        [Trait("Category", "Employee Service Mock Tests")]
        public void EmployeeService_GetAllActive_MustReturnOnlyActiveEmployees()
        {
            // Arrange
            Mock<IEmployeeRepository> employeeRepo = new Mock<IEmployeeRepository>();
            Mock<IMediator> mediatr = new Mock<IMediator>();

            employeeRepo
                .Setup(e => e.GetAll())
                .Returns(_employeeBogusTestsFixture.CreateVariedEmployees());

            EmployeeService employeeService = new EmployeeService(employeeRepo.Object, mediatr.Object);

            // Act
            IEnumerable<Employee> employees = employeeService.GetAllActive();

            // Assert
            employeeRepo.Verify(r => r.GetAll(), Times.Once);
            Assert.True(employees.Any());
            Assert.False(employees.Count(e => !e.Active) > 0);
        }
    }
}
