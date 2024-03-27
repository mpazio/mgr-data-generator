namespace DataGenerator.Databases;

public class CouchDb : IDatabase
{
    public string[] GenerateInserts(string[] jsonValues)
    {
        return new Generic().GenerateInserts(jsonValues);
    }
}