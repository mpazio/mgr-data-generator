using DataGenerator.Databases;
using DataGenerator.Utils;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [Theory]
        [MemberData(nameof(DatabaseTestData))]
        public void ReturnsTrueIfCorrectDatabaseIsPassed(string database)
        {
            //Arrange

            //Act
            var result = ArgumentChecker.CheckIfFirstArgumentIsCorrectDatabase(database);

            //Assert
            Assert.True(result);
        }

        public static IEnumerable<object[]> DatabaseTestData => Enum.GetValues(typeof(PossibleDatabases))
                .Cast<PossibleDatabases>()
                .Select(e => new object[] { e.ToString().ToLower() });
    }
}
