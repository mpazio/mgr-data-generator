using System.Text.Json;
using CommandDotNet;
using DataGenerator.Databases;
using DataGenerator.Utils;

namespace DataGenerator.Configurations;

public class Commands
{
    [Command]
    public async Task Generate(
        [Operand("database", Description = "Name of the database for which data will be generated")]
        PossibleDatabases databases, 
        [Operand("numberOfData", Description = "Number of data that will be generated")]
        int numberOfData, 
        [Option('f', "filepath", Description = "Path where inserts file will be created")] 
        string path = ".",
        [Option('s', "seed", Description = "Seed that will be used in Faker")] 
        int seed = 1
    )
    {
        JsonSerializerOptions options = new JsonSerializerOptions() { 
            WriteIndented = false, 
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
        };

        var insertGenerator = new InsertGenerator(databases);
        var inserts = insertGenerator.GenerateInserts(numberOfData, options, seed);

        await FileSaver.Save(inserts, databases.ToString(), path);
    }
}