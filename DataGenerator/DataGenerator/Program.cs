using DataGenerator.Utils;
using System.Text.Json;

ProgramArguments.Check(args);
string database = ProgramArguments.GetDatabase(args);
int numberOfData = ProgramArguments.GetNumberOfData(args);

JsonSerializerOptions options = new JsonSerializerOptions() { 
    WriteIndented = false, 
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
};

var insertGenerator = new InsertGenerator(database);
var inserts = insertGenerator.GenerateInserts(numberOfData, options);

await FileSaver.Save(inserts, database);