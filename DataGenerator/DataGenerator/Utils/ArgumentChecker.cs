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
        }
    }
}
