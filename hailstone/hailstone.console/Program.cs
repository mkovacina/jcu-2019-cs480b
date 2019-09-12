using System;
using hailstone.core;

namespace hailstone.console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.Error.WriteLine("usage: dotnet hailstone.console <input as integer>");
                return;
            }

            bool result = long.TryParse(args[0], out long input);

            if (!result)
            {
                Console.Error.WriteLine("The input was not an integer.");
                return;
            }

            HailstoneNumberGenerator generator = new NaiveHailstoneNumberGenerator();

            long hailstoneNumber = generator.ComputeHailstoneNumber(input);

            Console.WriteLine(hailstoneNumber);
        }
    }
}
