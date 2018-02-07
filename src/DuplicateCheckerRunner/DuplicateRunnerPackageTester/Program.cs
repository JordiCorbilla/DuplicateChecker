using DuplicateCheckerLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DuplicateRunnerPackageTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.Write("Calculating....");

            List<Item> items = new List<Item> {
                new Item { Id = 1, Name = "aaa" },
                new Item { Id = 2, Name = "aab" },
                new Item { Id = 3, Name = "aba" },
                new Item { Id = 4, Name = "aba" }
            };

            //Test using the new library
            Processor p = new Processor(items);
            p.FindDuplicates();
            Console.WriteLine("");
            Console.WriteLine("Duplicates");
            foreach (var value in p.exact)
            {
                Console.WriteLine($"{value.ToString()}");
            }
            Console.WriteLine("");
            Console.WriteLine("Close Fit");
            foreach (var value in p.closeFit)
            {
                Console.WriteLine($"{value.ToString()}");
            }
            Console.WriteLine("");
            Console.WriteLine("Similar");
            foreach (var value in p.similar)
            {
                Console.WriteLine($"{value.ToString()}");
            }
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.ReadKey();
        }
    }
}
