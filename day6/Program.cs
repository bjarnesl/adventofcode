using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace day6
{
    class Program
    {
        private static InputFetcher fetcher = new InputFetcher();
        static void Main(string[] args)
        {
            part1();
            part2();
        }

        static void part1()
        {
            int answerCount = 0;
            var input = fetcher.GetInputAsString(InputFetcher.day6p1);
            var groups = input.Split(new string[] { "\r\n\r\n" },
                               StringSplitOptions.RemoveEmptyEntries); 
            foreach (var group in groups)
            {
                
                var asnwers = string.Join(',', group.Replace("\r\n",""));
                answerCount += asnwers.Distinct().Count();
            }
            Console.WriteLine($"Unique answers: {answerCount}");
        }

        static void part2()
        {
            int answerCount = 0;
            var input = fetcher.GetInputAsString(InputFetcher.day6p1);
            var groups = input.Split(new string[] { "\r\n\r\n" },
                               StringSplitOptions.RemoveEmptyEntries);
            foreach (var group in groups)
            {
                var answers = group.Split(new string[] { "\r\n" },
                               StringSplitOptions.RemoveEmptyEntries).ToList();
                List<List<char>> generated = new List<List<char>>();
                foreach (var item in answers)
                {
                    var charlist = item.Select(c => c).ToList();
                    generated.Add(charlist);
                }
                var intersection = generated.Aggregate((previousList, nextList) => previousList.Intersect(nextList).ToList());
                answerCount += intersection.Select(c =>c).Count();
            }
            Console.WriteLine($"Unique answers: {answerCount}");
        }
    }
}
