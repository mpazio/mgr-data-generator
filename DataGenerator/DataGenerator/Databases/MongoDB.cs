namespace DataGenerator.Databases
{
    public class MongoDB : IDatabase
    {
        public string[] GenerateInserts(string[] jsonValues)
        {
            string tableName = "jsondata";
            string[] queries = new string[jsonValues.Length];

            for (int i = 0; i < jsonValues.Length; i++)
            {
                var json = jsonValues[i];
                string query = $"db.{tableName}.insertOne({json})";
                queries[i] = query;
            }

            return queries;
        }
    }
}
