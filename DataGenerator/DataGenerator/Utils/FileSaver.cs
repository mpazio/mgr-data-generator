namespace DataGenerator.Utils
{
    public static class FileSaver
    {
        public static async Task Save(string[] querys, string database, string? path = null)
        {
            string pathWithFileName = $"{path ?? string.Empty}/{database}inserts.txt";
            await File.WriteAllLinesAsync(pathWithFileName, querys);
        }
    }
}
