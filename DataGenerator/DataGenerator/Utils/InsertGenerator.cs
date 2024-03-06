using Bogus;
using DataGenerator.Configurations;
using DataGenerator.Data;
using DataGenerator.Databases;
using System.Text.Json;

namespace DataGenerator.Utils
{
    public class InsertGenerator
    {
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
                case PossibleDatabases.MongoDB:
                    Database = new MongoDB();
                    break;
                case PossibleDatabases.Redis:
                    Database = new Redis();
                    break;
                default:
                    Database = new Oracle();
                    break;
            }
        }

        public string[] GenerateInserts(int amount, JsonSerializerOptions options)
        {
            if (amount < 1) return new string[] { };

            var users = FakerSetup.SetupUser();
            string[] jsons = GenerateJsons(amount, users, options);

            var inserts = Database.GenerateInserts(jsons);
            return inserts;
        }

        public string[] GenerateJsons(int amount, Faker<User> users, JsonSerializerOptions options)
        {
            if (amount < 1) return new string[] { };

            string[] jsons = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                var user = users.Generate();
                string json = JsonSerializer.Serialize(user, options);
                jsons[i] = json;
            }

            return jsons;
        }
    }
}
