using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace day7
{
    class Program
    {
        private static InputFetcher fetcher = new InputFetcher();
        static void Main(string[] args)
        {
            part2();

        }

        private static void part1()
        {
            var input = fetcher.GetInputAsLines(InputFetcher.day7p1);
            foreach (var item in input)
            {
                string definitionSplitter = "bags contain";
                var inputsplit = item.Split(definitionSplitter);
                var name = inputsplit[0].Substring(0, inputsplit[0].Length).Trim();
                var children = inputsplit[1].Split(',');
                foreach (var child in children)
                {
                    var childef = child.Trim().Split(' ');
                    var number = childef[0];
                    var desc = string.Join(' ',childef[1] ,childef[2]);
                    BagRuleRepo.Add(name, new[] { desc });
                }
                
            }
            List<string> result = new List<string>();
            AddHolderAndCheckIfIsChild("shiny gold", result);
            var total = result.Distinct();
            Console.WriteLine($"Total possible holders: {total.Count()}");
           
        }


        public static void AddHolderAndCheckIfIsChild(string name, List<string> result)
        {
            var candidateRules = BagRuleRepo.Rules.Where(r => r.Value.Contains(name));
            foreach (var rule in candidateRules)
            {
                AddHolderAndCheckIfIsChild(rule.Key, result);
            }
           result.AddRange(candidateRules.Select(r => r.Key));
        }

        private static void part2()
        {
            var input = fetcher.GetInputAsLines(InputFetcher.day7p1s1);
            foreach (var item in input)
            {
                string definitionSplitter = "bags contain";
                var inputsplit = item.Split(definitionSplitter);
                var name = inputsplit[0].Substring(0, inputsplit[0].Length).Trim();
                var children = inputsplit[1].Split(',');
                foreach (var child in children)
                {
                    var childef = child.Trim().Split(' ');
                    var number = childef[0];
                    var desc = string.Join(' ', childef[1], childef[2]);
                    BagRuleRepo.Add(name, new[] { desc });
                }

            }
            List<string> result = new List<string>();
            AddHolderAndCheckIfIsChild("shiny gold", result);
            var total = result.Distinct();
            Console.WriteLine($"Total possible holders: {total.Count()}");

        }

        public static void AddHolderAndCheckIfIsChildWithCount(string name, List<string> result)
        {
            var candidateRules = BagRuleRepo.Rules.Where(r => r.Value.Contains(name));
            foreach (var rule in candidateRules)
            {
                AddHolderAndCheckIfIsChild(rule.Key, result);
            }
            result.AddRange(candidateRules.Select(r => r.Key));
        }

    }

    static class BagRuleRepov2
    {
        public static List<Bag> Rules = new List<Bag>();
        public static void Add(string name, string[] children)
        {
            if (!Rules.Any(b => b.Name == name))
            {
                Rules.Add(name, children);
            }
            else
            {
                Rules[name] = Rules[name].Union(children).Distinct().ToArray();
            }


        }
    }

    class Bag
    {
        public string Name;
        public Dictionary<string, int> childMinimum = new Dictionary<string, int>();

    }

    static class BagRuleRepo
    {
        public static Dictionary<string, string[]> Rules = new Dictionary<string, string[]>();
        public static void Add(string name, string[] children )
        {
            if (!Rules.ContainsKey(name))
            {
                Rules.Add(name, children);
            }
            else
            {
                Rules[name] = Rules[name].Union(children).Distinct().ToArray();
            }


        }
    }
}
