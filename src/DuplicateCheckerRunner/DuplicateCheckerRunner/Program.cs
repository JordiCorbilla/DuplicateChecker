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

namespace DuplicateCheckerRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var spin = new ConsoleOutput();
            List<string[]> l = new List<string[]>
            {
                new[]{"Coca Cola", "Coca Cola Ltd."},
                new[]{"Method", "Methods"},
                new[]{"Potato", "Ketchup"},
                new[]{"Potato", "Potato mix"},
                new[]{"Tarakan", "Potato mix"},
                new[]{"Tenggarong", "Gorontalo"},
                new[]{"Ambon", "Makasar"},
                new[]{"Tual", "Manado"},
                new[]{"Ternate", "Palu"},
                new[]{"Tidore", "Pare-Pare"},
                new[]{"Bima", "Palopo"},
                new[]{"Mataram", "Tomohon"},
                new[]{"Kupang", "Banda Aceh"},
                new[]{"Atambua", "Potato mix"},
                new[]{"Jayapura", "Potato mix"},
                new[]{"Merauke", "Potato mix"},
                new[]{"Kota Sorong", "Potato mix"},
                new[]{"Monokwari", "Potato mix"},
                new[]{"Bau-Bau", "Potato mix"},
                new[]{"Bitung", "Potato mix"} 
            };

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.Write("Calculating....");
            List<string> output = new List<string>();
            foreach (string[] a in l)
            {
                spin.Rotate();
                int cost = LevenshteinDistance.Get(a[0], a[1]);
                output.Add($"{a[0]} -> {a[1]} = {cost}");
            }

            Console.WriteLine("");
            foreach (var value in output)
            {
                Console.WriteLine($"{value}");
            }
            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed);
            Console.ReadKey();
        }
    }
}
