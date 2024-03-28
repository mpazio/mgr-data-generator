using Bogus;
using DataGenerator.Configurations;
using DataGenerator.Data;
using DataGenerator.Databases;
using System.Text.Json;
using DataGenerator.Data.Quest;

namespace DataGenerator.Utils
{
    public class InsertGenerator
    {
        public IDatabase Database { get; set; }
        public InsertGenerator(PossibleDatabases database)
        {
            // Enum.TryParse(database, true, out PossibleDatabases db);
            Database = database switch
            {
                PossibleDatabases.Generic => new Generic(),
                PossibleDatabases.Oracle => new Oracle(),
                PossibleDatabases.SqlServer => new SqlServer(),
                PossibleDatabases.Postgres => new Postgres(),
                PossibleDatabases.MongoDB => new MongoDB(),
                PossibleDatabases.Redis => new Redis(),
                PossibleDatabases.Couchbase => new Couchbase(),
                PossibleDatabases.CouchDb => new CouchDb(),
                _ => new Generic()
            };
        }

        public string[] GenerateInserts(int amount, JsonSerializerOptions options, int seed)
        {
            if (amount < 1) return new string[] { };

            var users = FakerSetup.SetupUser(seed);
            string[] jsons = GenerateJsons(amount, users, options);

            var inserts = Database.GenerateInserts(jsons);
            return inserts;
        }
        
        public string[] GenerateInsertsInBatches(int amount, JsonSerializerOptions options, Faker<User> users)
        {
            if (amount < 1) return new string[] { };
            
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
        
        public string[] GenerateInsertsInBatchesForPolymorphicData(int amount, JsonSerializerOptions options, Faker<Quest> quests)
        {
            if (amount < 1) return new string[] { };
            
            string[] jsons = GenerateJsonsForPolymorphicData(amount, quests, options);

            var inserts = Database.GenerateInserts(jsons);
            return inserts;
        }
        
        public string[] GenerateJsonsForPolymorphicData(int amount, Faker<Quest> quests, JsonSerializerOptions options)
        {
            if (amount < 1) return new string[] { };

            string[] jsons = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                var quest = quests.Generate();
                string json = JsonSerializer.Serialize(quest, options);
                jsons[i] = json;
            }

            return jsons;
        }
    }
}
