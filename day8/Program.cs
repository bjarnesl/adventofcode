using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace day8
{
    class Program
    {
        static int accumulator = 0;
        static void Main(string[] args)
        {
            //part1();
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
          
            int itemcounter = 0;
            foreach (var item in input)
            {
                accumulator = 0;

                if (input[itemcounter].StartsWith("jmp"))
                    {
                    input[itemcounter] = input[itemcounter].Replace("jmp", "nop");
                    }
                else if (input[itemcounter].StartsWith("nop"))
                {
                    input[itemcounter] = input[itemcounter].Replace("nop", "jmp");
                }
              
            
            int pointer = 0;
            List<int> processedLines = new List<int>();
            while (!processedLines.Contains(pointer))
            {
                if(pointer == input.Length)
                {
                    Console.WriteLine($"Completed program. Accumulator value: {accumulator}");
                }
                processedLines.Add(pointer);
                pointer += processLine(input[pointer]);

                if (pointer == input.Length)
                {
                    Console.WriteLine($"Completed program. Accumulator value: {accumulator}");
                }

            }
                if (input[itemcounter].StartsWith("jmp"))
                {
                    input[itemcounter] = input[itemcounter].Replace("jmp", "nop");
                }
                else if (input[itemcounter].StartsWith("nop"))
                {
                    input[itemcounter] = input[itemcounter].Replace("nop", "jmp");
                }
                itemcounter++;
            }


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
