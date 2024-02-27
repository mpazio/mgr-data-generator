using DataGenerator.Databases;
using System.Text.Json;

namespace DataGenerator.Utils
{
    public class InsertGenerator
    {
        JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = false, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        public IDatabase Database { get; set; }
        public InsertGenerator(string database)
        {
            Enum.TryParse(database, true, out PossibleDatabases db);
            switch (db)
            {
                case PossibleDatabases.Oracle:
                    Database = new Oracle();
                    break;
                case PossibleDatabases.SqlServer:
                    Database = new SqlServer();
                    break;
                case PossibleDatabases.Postgres:
                    Database = new Postgres();
                    break;
                default:
                    Database = new Oracle();
                    break;
            }
        }
    }
}
