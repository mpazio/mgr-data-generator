using DataGenerator.Databases;
using DataGenerator.Utils;

namespace DataGenerator.Tests
{
    public class InsertGeneratorTests
    {
        #region InsertGeneratorConstructor
        [Fact]
        public void SetDefaultDatabaseAsOracle()
        {
            //Arrange
            string database = "anythingThatIsNotDatabaseName";

            //Act
            InsertGenerator insertGenerator = new InsertGenerator(database);

            //Assert
            Assert.IsType<Oracle>(insertGenerator.Database);
        }

        [Fact]
        public void SetDatabaseAsOracle()
        {
            //Arrange
            string database = "oracle";

            //Act
            InsertGenerator insertGenerator = new InsertGenerator(database);

            //Assert
            Assert.IsType<Oracle>(insertGenerator.Database);
        }

        [Fact]
        public void SetDatabaseAsSqlServer()
        {
            //Arrange
            string database = "sqlserver";

            //Act
            InsertGenerator insertGenerator = new InsertGenerator(database);

            //Assert
            Assert.IsType<SqlServer>(insertGenerator.Database);
        }

        [Fact]
        public void SetDatabaseAsPostgres()
        {
            //Arrange
            string database = "postgres";

            //Act
            InsertGenerator insertGenerator = new InsertGenerator(database);

            //Assert
            Assert.IsType<Postgres>(insertGenerator.Database);
        }
        #endregion


        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void ReturnEmptyArrayIfAmountIsLowerThanOne(int amount)
        {
            //Arrange
            InsertGenerator insertGenerator = new InsertGenerator("oracle");

            //Act
            var result = insertGenerator.GenerateInserts(amount);

            //Assert
            Assert.True(result.Length < 1);
        }
    }
}
