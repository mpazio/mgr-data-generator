namespace DataGenerator.Databases
{
    public class Oracle : IDatabase
    {
        public string[] GenerateInserts(string[] jsonValues)
        {
            string tableName = "jsondata";
            string[] queries = new string[jsonValues.Length];

            for (int i = 0; i < jsonValues.Length; i++)
            {
                var json = jsonValues[i];
                string query = $"INSERT INTO {tableName} VALUES (SYS_GUID(), '{json}');";
                queries[i] = query;
            }

            return queries;
        }
    }
}
