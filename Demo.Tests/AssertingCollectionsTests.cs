using Xunit;

namespace Demo.Tests
{
    public class AssertingCollectionsTests
    {

        [Fact]
        public void EmployeeFactory_Skills_MustNotHaveEmptySkills()
        {
            //Arrange & Act
            Employee employee = EmployeFactory.Create("Caio", 10000);

            //Assert
            Assert.All(employee.Skills, skill => Assert.False(string.IsNullOrEmpty(skill)));
        }        
        
        [Fact]
        public void EmployeeFactory_Skills_JuniorMustHaveBasicSkill()
        {
            //Arrange & Act
            Employee employee = EmployeFactory.Create("Caio", 1000);

            //Assert
            Assert.Contains("OOP", employee.Skills);
        }    
        
        [Fact]
        public void EmployeeFactory_Skills_JuniorMustNotHaveAdvancedSkill()
        {
            //Arrange & Act
            Employee employee = EmployeFactory.Create("Caio", 1000);

            //Assert
            Assert.DoesNotContain("Microsservices", employee.Skills);
        }        
        
        [Fact]
        public void EmployeeFactory_Skills_SeniorMustHaveAllSkills()
        {
            //Arrange & Act
            Employee employee = EmployeFactory.Create("Caio", 15000);

            var skills = new[]
            {
                "Software Logic",
                "OOP",
                "Tests",
                "Microsservices"
            };

            //Assert
            Assert.Equal(skills, employee.Skills);
        }
    }
}
