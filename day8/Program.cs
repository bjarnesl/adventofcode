using Common;
using System;
using System.Collections.Generic;

namespace day8
{
    class Program
    {
        static int accumulator = 0;
        static void Main(string[] args)
        {
            part1();
            part2();
        }

        private static void part1()
        {
            var input = InputFetcher.GetInputAsLines(InputFetcher.day8p1);
            int pointer = 0;
            List<int> processedLines = new List<int>();
            while(!processedLines.Contains(pointer))
            {
                processedLines.Add(pointer);
                pointer +=  processLine(input[pointer]);
            }
            Console.WriteLine($"Accumulator currently at {accumulator}");
            

            
        }
        private static void part2()
        {
            var input = InputFetcher.GetInputAsLines(InputFetcher.day8p1);
            int pointer = 0;
            List<int> processedLines = new List<int>();
            while (!processedLines.Contains(pointer))
            {
                processedLines.Add(pointer);
                pointer += processLine(input[pointer]);
            }
            Console.WriteLine($"Accumulator currently at {accumulator}");



        }

        static int processLine(string line)
        {
            var linesplit = line.Split(' ');
            var command = linesplit[0];
            var argument = linesplit[1];

            switch (command)
            {
                case "nop":
                    return 1;
                case "acc":
                    accumulator += int.Parse(argument);
                    return 1;
                case "jmp":
                    return int.Parse(argument);
                default:
                    break;
            }
            return -1;
        }

        
    }
}
