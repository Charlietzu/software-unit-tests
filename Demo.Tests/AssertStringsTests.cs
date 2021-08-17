using Xunit;

namespace Demo.Tests
{
    public class AssertStringsTests
    {
        [Fact]
        public void StringsTools_JoinNames_ReturnFullName()
        {
            //Arrange
            StringsTools sut = new StringsTools();

            //Act
            string fullName = sut.Join("Caio", "César");

            //Assert
            Assert.Equal("Caio César", fullName);
        }       
        
        [Fact]
        public void StringsTools_JoinNames_MustIgnoreCase()
        {
            //Arrange
            StringsTools sut = new StringsTools();

            //Act
            string fullName = sut.Join("Caio", "César");

            //Assert
            Assert.Equal("CAIO CÉSAR", fullName, true);
        }        
        
        [Fact]
        public void StringsTools_JoinNames_MustContainSubString()
        {
            //Arrange
            StringsTools sut = new StringsTools();

            //Act
            string fullName = sut.Join("Caio", "César");

            //Assert
            Assert.Contains("aio", fullName);
        }        
        
        [Fact]
        public void StringsTools_JoinNames_MustStartWith()
        {
            //Arrange
            StringsTools sut = new StringsTools();

            //Act
            string fullName = sut.Join("Caio", "César");

            //Assert
            Assert.StartsWith("Cai", fullName);
        }    
        
        [Fact]
        public void StringsTools_JoinNames_MustEndWith()
        {
            //Arrange
            StringsTools sut = new StringsTools();

            //Act
            string fullName = sut.Join("Caio", "César");

            //Assert
            Assert.EndsWith("sar", fullName);
        }        
        
        [Fact]
        public void StringsTools_JoinNames_ValidateRegularExpression()
        {
            //Arrange
            StringsTools sut = new StringsTools();

            //Act
            string fullName = sut.Join("Caio", "Cesar");

            //Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", fullName);
        }
    }
}
