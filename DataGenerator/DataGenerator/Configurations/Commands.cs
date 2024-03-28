using System.Text.Encodings.Web;
using System.Text.Json;
using CommandDotNet;
using DataGenerator.Configurations.Quests;
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
        int seed = 1,
        [Option('b', "batch", Description = "Number of batches that inserts are divide")] 
        int batches = 1,
        [Option('d', "data", Description = "Number of batches that inserts are divide")] 
        GeneratedDataTypes dataType = GeneratedDataTypes.Normal
    )
    {
        JsonSerializerOptions options = new JsonSerializerOptions() { 
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };

        var insertGenerator = new InsertGenerator(databases);
       
        
        int numberOfDataInBatch = numberOfData / batches;
        int remainder = numberOfData % batches;

        numberOfData = numberOfDataInBatch + remainder;
        
        
        if(dataType == GeneratedDataTypes.Normal)
            await GenerateUserData(databases, numberOfData, path, seed, batches, insertGenerator, options, numberOfDataInBatch);
        else 
            await GeneratePolymorphicDat(databases, numberOfData, path, seed, batches, insertGenerator, options, numberOfDataInBatch);
            
    }

    private static async Task GenerateUserData(PossibleDatabases databases, int numberOfData, string path, int seed, int batches,
        InsertGenerator insertGenerator, JsonSerializerOptions options, int numberOfDataInBatch)
    {
        var users = FakerSetup.SetupUser(seed);
        for (int i = 0; i < batches; i++)
        {
            Console.WriteLine(numberOfData);
            var inserts = insertGenerator.GenerateInsertsInBatches(numberOfData, options, users);
           
            await FileSaver.Save(inserts, databases.ToString() + $"_batch{i}_", path);
            numberOfData = numberOfDataInBatch;
        }
    }
    
    private static async Task GeneratePolymorphicDat(PossibleDatabases databases, int numberOfData, string path, int seed, int batches,
        InsertGenerator insertGenerator, JsonSerializerOptions options, int numberOfDataInBatch)
    {
        var quests = QuestsFakerSetup.SetupQuest(seed);
        for (int i = 0; i < batches; i++)
        {
            Console.WriteLine(numberOfData);
            var inserts = insertGenerator.GenerateInsertsInBatchesForPolymorphicData(numberOfData, options, quests);
           
            await FileSaver.Save(inserts, databases.ToString() + $"_batch{i}_", path);
            numberOfData = numberOfDataInBatch;
        }
    }
}