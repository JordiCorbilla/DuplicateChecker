using DuplicateCheckerLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DuplicateCheckerRunner
{
    public class Runner
    {
        static readonly object _locker = new object();
        private readonly IDataRepository _dataRepository;
        public Runner(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public void Run()
        {
            var output = new ConsoleOutput();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Match> closeFit = new List<Match>();
            List<Match> exact = new List<Match>();
            List<Match> similar = new List<Match>();
            List<Match> different = new List<Match>();
            Dictionary<string, bool> keys = new Dictionary<string, bool>();

            //Give me the overal number of calculations here
            int repetitions = MathLib.NumberOfPermutationsNoRepetition(_dataRepository.GetComplex().Count-1);
            Console.WriteLine($"Number of items to calculate: {repetitions.ToString()}");
            Console.WriteLine("Calculating....");
            //Loop through all the data
            //Highly cpu intensive
            int count = 0;
            foreach (Item left in _dataRepository.GetComplex())
            {
                foreach (Item right in _dataRepository.GetComplex())
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
                            output.Rotate(count, repetitions, $"Time elapsed: {s1.Elapsed}" );
                            switch (cost.Type)
                            {
                                case MatchType.CloseFit:
                                    closeFit.Add(cost);
                                    break;
                                case MatchType.Exact:
                                    exact.Add(cost);
                                    break;
                                case MatchType.Similar:
                                    similar.Add(cost);
                                    break;
                                case MatchType.Different:
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

        public void RunFromDB()
        {
            var output = new ConsoleOutput();

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
            List<Item> repository = _dataRepository.LoadFromTable();
            foreach (Item left in repository)
            {
                foreach (Item right in repository)
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
                                case MatchType.CloseFit:
                                    closeFit.Add(cost);
                                    break;
                                case MatchType.Exact:
                                    exact.Add(cost);
                                    break;
                                case MatchType.Similar:
                                    similar.Add(cost);
                                    break;
                                case MatchType.Different:
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
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.ReadKey();
        }

        public void RunParallelMax()
        {
            var degreeOfParallelism = Environment.ProcessorCount;
            var output = new ConsoleOutput();

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
            foreach (Item left in _dataRepository.GetComplex())
            {
                var last = _dataRepository.GetComplex().Last();
                foreach (Item right in _dataRepository.GetComplex())
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
                                    case MatchType.CloseFit:
                                        closeFit.Add(cost);
                                        break;
                                    case MatchType.Exact:
                                        exact.Add(cost);
                                        break;
                                    case MatchType.Similar:
                                        similar.Add(cost);
                                        break;
                                    case MatchType.Different:
                                        different.Add(cost);
                                        break;
                                }
                                //Monitor.Exit(_locker);
                            });
                            taskNumber++;
                        }
                    }
                    if (taskNumber == degreeOfParallelism)
                    {
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

        public void RunParallel()
        {
            var degreeOfParallelism = Environment.ProcessorCount;
            var spin = new ConsoleOutput();

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
            foreach (Car left in _dataRepository.Get())
            {
                foreach (Car right in _dataRepository.Get())
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

                            //spin.Rotate();
                            tasks.Add(i, new Task(() => {
                                Match cost = LevenshteinDistance.Get(left.Name, right.Name);
                                switch (cost.Type)
                                {
                                    case MatchType.CloseFit:
                                        closeFit.Add(cost);
                                        break;
                                    case MatchType.Exact:
                                        exact.Add(cost);
                                        break;
                                    case MatchType.Similar:
                                        similar.Add(cost);
                                        break;
                                    case MatchType.Different:
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
