﻿using DataGenerator.Databases;

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
            string numberOfData = args[1];

            if (!CheckIfFirstArgumentIsCorrectDatabase(database))
                throw new ArgumentException("Incorrect database!");
            if(!CheckIfSecondArgumentIsANumber(numberOfData))
                throw new ArgumentException("Second argument must be a number!");
        }

        public static bool CheckIfFirstArgumentIsCorrectDatabase(string arg)
        {
            var enums = Enum.GetValues(typeof(PossibleDatabases))
                .Cast<PossibleDatabases>()
                .Select(e => e.ToString()
                .ToLower());

            return enums.Contains(arg.ToLower());
        }

        public static bool CheckIfSecondArgumentIsANumber(string arg)
        {
            int num;
            bool test = int.TryParse(arg, out num);
            return test;
        }
    }
}
