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
    }
}
