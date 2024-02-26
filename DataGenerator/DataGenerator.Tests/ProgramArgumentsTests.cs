using DataGenerator.Utils;

namespace DataGenerator.Tests
{
    public class ProgramArgumentsTests
    {
        [Fact]
        public void RunAppWithNoArguments()
        {
            //Arrange

            //Act
            Action action = () => ArgumentChecker.CheckArguments(null!);

            //Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void RunAppWithEmptyArgumentsList()
        {
            //Arrange

            //Act
            Action action = () => ArgumentChecker.CheckArguments(new string[] { });

            //Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void CheckNumberOfArguments()
        {
            //Arrange

            //Act
            Action action = () => ArgumentChecker.CheckArguments(new string[] { "single" });

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public void ThrowsExceptionIfWrongDatabaseIsPassed()
        {
            //Arrange

            //Act
            Action action = () => ArgumentChecker.CheckArguments(new string[] { "NonExistingDatabase", "1000" });

            //Assert
            Assert.Throws<ArgumentException>(action);
            var exception = Record.Exception(action);
            Assert.Equal("Incorrect database!", exception.Message);
        }
    }
}
