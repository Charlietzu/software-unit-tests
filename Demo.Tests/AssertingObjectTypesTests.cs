using Xunit;

namespace Demo.Tests
{
    public class AssertingObjectTypesTests
    {
        [Fact]
        public void EmployeeFactory_Create_MustReturnEmployeeType()
        {
            //Arrange & Act
            Employee employee = EmployeFactory.Create("Caio", 10000);

            //Assert
            Assert.IsType<Employee>(employee);
        }

        [Fact]
        public void EmployeeFactory_Create_MustReturnDerivedEmployeeType()
        {
            //Arrange & Act
            Employee employee = EmployeFactory.Create("Caio", 10000);

            //Assert
            Assert.IsAssignableFrom<Employee>(employee);
        }
    }
}
