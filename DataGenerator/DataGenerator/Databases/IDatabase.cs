namespace DataGenerator.Databases
{
    public interface IDatabase
    {
        string[] GenerateInserts(string[] jsonValues);
    }
}
