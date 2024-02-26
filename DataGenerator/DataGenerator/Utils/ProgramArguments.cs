using DataGenerator.Databases;

namespace DataGenerator.Utils
{
    public static class ProgramArguments
    {
        public static void Check(string[] args)
        {
            if (args is null || args.Length < 1)
                throw new ArgumentNullException(nameof(args));
            if (args.Length != 2 )
                throw new ArgumentOutOfRangeException(nameof(args));

            string database = GetDatabase(args);
            string numberOfData = args[1];

            if (!IsArgumentACorrectDatabase(database))
                throw new ArgumentException("Incorrect database!");
            if(!IsSecondArgumentANumber(numberOfData))
                throw new ArgumentException("Second argument must be a number!");
        }

        public static bool IsArgumentACorrectDatabase(string arg)
        {
            var enums = Enum.GetValues(typeof(PossibleDatabases))
                .Cast<PossibleDatabases>()
                .Select(e => e.ToString()
                .ToLower());

            return enums.Contains(arg.ToLower());
        }

        public static bool IsSecondArgumentANumber(string arg)
        {
            int num;
            bool test = int.TryParse(arg, out num);
            return test;
        }

        public static string GetDatabase(string[] args)
        {
            if (args is null || args.Length < 1) return "";
            return args[0];
        }


        public static int GetNumberOfData(string[] args)
        {
            if (args is null || args.Length < 2) return 0;
            return int.Parse(args[1]);
        }
    }
}
