namespace DataGenerator.Databases;

public class Generic : IDatabase
{
    public string[] GenerateInserts(string[] jsonValues)
    {
        string[] queries = new string[jsonValues.Length];
        for (int i = 0; i < jsonValues.Length; i++)
        {
            var json = jsonValues[i];
            string query = $"{json}";
            queries[i] = query;
        }

        return queries;
    }
}