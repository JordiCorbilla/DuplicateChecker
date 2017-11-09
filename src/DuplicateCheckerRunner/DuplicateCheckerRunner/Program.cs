//  Copyright (c) 2017, Jordi Corbilla
//  All rights reserved.
//
//  Redistribution and use in source and binary forms, with or without
//  modification, are permitted provided that the following conditions are met:
//
//  - Redistributions of source code must retain the above copyright notice,
//    this list of conditions and the following disclaimer.
//  - Redistributions in binary form must reproduce the above copyright notice,
//    this list of conditions and the following disclaimer in the documentation
//    and/or other materials provided with the distribution.
//  - Neither the name of this library nor the names of its contributors may be
//    used to endorse or promote products derived from this software without
//    specific prior written permission.
//
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
//  AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
//  ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE
//  LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
//  CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
//  SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
//  INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
//  CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
//  ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
//  POSSIBILITY OF SUCH DAMAGE.

using DuplicateCheckerLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DuplicateCheckerRunner
{
    class Program
    {
        static readonly object _locker = new object();

        static void Main(string[] args)
        {
            Run();
            //RunParallelMax();
            //RunParallel();
        }

        static void Run()
        {
            var output = new ConsoleOutput();
            DataRepository data = new DataRepository();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.Write("Calculating....");
            List<Match> closeFit = new List<Match>();
            List<Match> exact = new List<Match>();
            List<Match> similar = new List<Match>();
            List<Match> different = new List<Match>();
            Dictionary<string, bool> keys = new Dictionary<string, bool>();

            //Loop through all the data
            //Highly cpu intensive
            int count = 0;
            foreach (Item left in data.GetComplex())
            {
                foreach (Item right in data.GetComplex())
                {
                    if (left.Id != right.Id)
                    {
                        string Id1 = $"{left.Id}-{right.Id}";
                        string Id2 = $"{right.Id}-{left.Id}";
                        bool value;
                        //only unique values
                        if (!keys.TryGetValue(Id1, out value) && !keys.TryGetValue(Id2, out value))
                        {
                            //This will ensure that we only look at real matches and no duplicated entries
                            keys.Add(Id1, true);
                            keys.Add(Id2, true);

                            Stopwatch s1 = new Stopwatch();
                            s1.Start();
                            Match cost = LevenshteinDistance.Get(left.Name, right.Name);
                            count++;
                            s1.Stop();
                            //output.Rotate($"{count++.ToString()} Time elapsed: {s1.Elapsed}" );
                            switch (cost.Type)
                            {
                                case MatchType.closefit:
                                    closeFit.Add(cost);
                                    break;
                                case MatchType.exact:
                                    exact.Add(cost);
                                    break;
                                case MatchType.similar:
                                    similar.Add(cost);
                                    break;
                                case MatchType.different:
                                    different.Add(cost);
                                    break;
                            }

                        }
                    }
                }
            }

            Console.WriteLine($"Number of items processed: {count++.ToString()}");
            output.OutputResults("Duplicates", exact);
            output.OutputResults("Close Fit", closeFit);
            output.OutputResults("Similar", similar);
            //Console.WriteLine("");
            //Console.WriteLine("Different");
            //foreach (var value in different)
            //{
            //    Console.WriteLine($"{value.ToString()}");
            //}
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.ReadKey();
        }

        static void RunParallelMax()
        {
            var degreeOfParallelism = Environment.ProcessorCount;
            var output = new ConsoleOutput();
            DataRepository data = new DataRepository();
            

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.Write("Calculating....");
            List<Match> closeFit = new List<Match>();
            List<Match> exact = new List<Match>();
            List<Match> similar = new List<Match>();
            List<Match> different = new List<Match>();
            Dictionary<string, bool> keys = new Dictionary<string, bool>();

            //Loop through all the data
            //Highly cpu intensive
            int count = 0;

            //Create a set of tasks to be run (max 8 as per my cpu cores)
            var tasks = new Task[degreeOfParallelism];
            int taskNumber = 0;
            foreach (Item left in data.GetComplex())
            {
                var last = data.GetComplex().Last();
                foreach (Item right in data.GetComplex())
                {

                    if (left.Id != right.Id)
                    {
                        string Id1 = $"{left.Id}-{right.Id}";
                        string Id2 = $"{right.Id}-{left.Id}";
                        bool value;
                        //only unique values
                        if (!keys.TryGetValue(Id1, out value) && !keys.TryGetValue(Id2, out value))
                        {
                            //This will ensure that we only look at real matches and no duplicated entries
                            keys.Add(Id1, true);
                            keys.Add(Id2, true);

                            tasks[taskNumber] = Task.Factory.StartNew(() =>
                            {
                                //Stopwatch s1 = new Stopwatch();
                                //s1.Start();
                                Match cost = LevenshteinDistance.Get(left.Name, right.Name);
                                count++;
                                //s1.Stop();
                                //Monitor.Enter(_locker);
                                //output.Rotate($"{count++.ToString()} Time elapsed: {s1.Elapsed}");
                                switch (cost.Type)
                                {
                                    case MatchType.closefit:
                                        closeFit.Add(cost);
                                        break;
                                    case MatchType.exact:
                                        exact.Add(cost);
                                        break;
                                    case MatchType.similar:
                                        similar.Add(cost);
                                        break;
                                    case MatchType.different:
                                        different.Add(cost);
                                        break;
                                }
                                //Monitor.Exit(_locker);
                            });
                            taskNumber++;
                        }
                    }
                    if (taskNumber == degreeOfParallelism) { 
                        Task.WaitAll(tasks);
                        taskNumber = 0;
                    }
                    if (right.Equals(last))
                    {
                        Task.WaitAll(tasks);
                        taskNumber = 0;
                    }
                }
            }

            Console.WriteLine($"Number of items processed: {count++.ToString()}");
            output.OutputResults("Duplicates", exact);
            output.OutputResults("Close Fit", closeFit);
            output.OutputResults("Similar", similar);
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);

            Console.ReadKey();
        }

        static void RunParallel()
        {
            var degreeOfParallelism = Environment.ProcessorCount;
            var spin = new ConsoleOutput();
            DataRepository data = new DataRepository();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.Write("Calculating....");
            List<Match> closeFit = new List<Match>();
            List<Match> exact = new List<Match>();
            List<Match> similar = new List<Match>();
            List<Match> different = new List<Match>();
            Dictionary<string, bool> keys = new Dictionary<string, bool>();
            Dictionary<int, Task> tasks = new Dictionary<int, Task>();

            //Loop through all the data
            //Highly cpu intensive
            int i = 0;
            foreach (Car left in data.Get())
            {
                foreach (Car right in data.Get())
                {
                    if (left.Id != right.Id)
                    {
                        string Id1 = $"{left.Id}-{right.Id}";
                        string Id2 = $"{right.Id}-{left.Id}";
                        bool value;
                        if (!keys.TryGetValue(Id1, out value) && !keys.TryGetValue(Id2, out value))
                        {
                            //This will ensure that we only look at real matches and no duplicated entries
                            keys.Add(Id1, true);
                            keys.Add(Id2, true);

                            spin.Rotate();
                            tasks.Add(i, new Task(() => {
                                Match cost = LevenshteinDistance.Get(left.Name, right.Name);
                                switch (cost.Type)
                                {
                                    case MatchType.closefit:
                                        closeFit.Add(cost);
                                        break;
                                    case MatchType.exact:
                                        exact.Add(cost);
                                        break;
                                    case MatchType.similar:
                                        similar.Add(cost);
                                        break;
                                    case MatchType.different:
                                        different.Add(cost);
                                        break;
                                }
                            }));
                            tasks[i++].Start();
                        }
                    }
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Duplicates");
            foreach (var value in exact)
            {
                Console.WriteLine($"{value.ToString()}");
            }
            Console.WriteLine("");
            Console.WriteLine("Close Fit");
            foreach (var value in closeFit)
            {
                Console.WriteLine($"{value.ToString()}");
            }
            Console.WriteLine("");
            Console.WriteLine("Similar");
            foreach (var value in similar)
            {
                Console.WriteLine($"{value.ToString()}");
            }
            //Console.WriteLine("");
            //Console.WriteLine("Different");
            //foreach (var value in different)
            //{
            //    Console.WriteLine($"{value.ToString()}");
            //}
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.ReadKey();
        }
    }
}
