using DataGenerator.Databases;

namespace DataGenerator.Utils
{
    public static class ArgumentChecker
    {
        public static void CheckArguments(string[] args)
        {
            if (args is null || args.Length < 1)
                throw new ArgumentNullException(nameof(args));
            if (args.Length != 2 )
                throw new ArgumentOutOfRangeException(nameof(args));

            string database = args[0];

            if (!CheckIfFirstArgumentIsCorrectDatabase(database))
                throw new ArgumentException("Incorrect database!");
        }

        public static bool CheckIfFirstArgumentIsCorrectDatabase(string arg)
        {
            var enums = Enum.GetValues(typeof(PossibleDatabases))
                .Cast<PossibleDatabases>()
                .Select(e => e.ToString()
                .ToLower());

            return enums.Contains(arg.ToLower());
        }
    }
}
