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
using System.Text;
using System.Threading;

namespace DuplicateCheckerRunner
{
    public class ConsoleOutput
    {
        private int _counter;

        public void Rotate(int count, int total, string text)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(28591);
            _counter++;
            string output = "";
            int percentage = (int)((double)((double)count / (double)total) * 100.0);
            switch (_counter % 4)
            {
                case 0:
                    output = $"{GetProgressBar(percentage)} /  {percentage}% {count} {text}";
                    Console.Write(output); _counter = 0; break;
                case 1:
                    output = $"{GetProgressBar(percentage)} -  {percentage}% {count} {text}";
                    Console.Write(output); break;
                case 2:
                    output = $"{GetProgressBar(percentage)} \\  {percentage}% {count} {text}";
                    Console.Write(output); break;
                case 3:
                    output = $"{GetProgressBar(percentage)} |  {percentage}% {count} {text}";
                    Console.Write(output); break;
            }
            Thread.Sleep(100);
            Console.SetCursorPosition(Console.CursorLeft - output.Length, Console.CursorTop);
        }

        //public void Rotate(int count, int total, string text)
        //{
        //    Rotate(count, total, text);
        //}

        public void OutputResults(string name, List<Match> list)
        {
            Console.WriteLine("");
            Console.WriteLine($"{name} ({list.Count})");
            foreach (var value in list)
            {
                Console.WriteLine($"{value.ToString()}");
            }
        }

        public string GetProgressBar(int percentage)
        {
            string progress ="";
            //Percentage needs to be adapted to be a value of 5
            char num = percentage.ToString()[percentage.ToString().Length - 1];
            int lastDigit = int.Parse(num.ToString());
            int numberToProcess = percentage;
            switch (lastDigit)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    numberToProcess = numberToProcess - lastDigit;
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                    numberToProcess = numberToProcess + (10 - lastDigit);
                    break;
            }
            for (int i = 0; i < numberToProcess; i = i + 5)
            {
                progress += $"{(char)219}";
            }
            string dots = "";
            for(int i=0; i < (100 - numberToProcess); i=i+5)
            {
                dots += ".";
            }
            return $"[{progress}{dots}]";
        }
    }
}
