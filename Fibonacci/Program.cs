using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Fibonacci
{
    class Program
    {
        private const int DEFAULT_COUNT = 25;

        static void Main(string[] args)
        {
            var count = DEFAULT_COUNT;
            ParseArguments();

            var fibonacciSequence = Fibonacci().Take(count);

            Console.WriteLine(String.Join(Environment.NewLine, fibonacciSequence));

            ExitApplication(0);

            IEnumerable<long> Fibonacci()
            {
                yield return 0;

                long previous = 0;
                long current = 1;

                while (true)
                {
                    yield return current;

                    unchecked
                    {
                        var tmp = current;
                        current = current + previous;
                        previous = tmp;
                    }

                    if (current < 0) break;
                }
            }

            void ExitApplication(int exitCode)
            {
                if (Debugger.IsAttached)
                {
                    Console.WriteLine("Press any key to exit");
                    Console.ReadKey(true);
                }

                Environment.Exit(exitCode);
            }

            void ParseArguments()
            {
                if (args.Length > 1)
                {
                    ShowHelp();
                    ExitApplication(1);
                }

                if (args.Length == 1)
                {
                    if (!Int32.TryParse(args[0], out count))
                    {
                        ShowHelp();
                        ExitApplication(1);
                    }
                }
            }

            void ShowHelp()
            {
                Console.WriteLine("bla");
            }
        }
    }
}
