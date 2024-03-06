namespace DataGenerator.Databases;

public class Redis : IDatabase
{
    public string[] GenerateInserts(string[] jsonValues)
    {
        string prefixName = "user";
        string[] queries = new string[jsonValues.Length];
        for (int i = 0; i < jsonValues.Length; i++)
        {
            var json = jsonValues[i];
            string query = $"JSON.SET {prefixName}:{i}  $ '{json}'";
            queries[i] = query;
        }

        return queries;
    }
}