namespace DataGenerator.Databases;

public class Couchbase : IDatabase
{
    public string[] GenerateInserts(string[] jsonValues)
    {
        return new Generic().GenerateInserts(jsonValues);
    }
}