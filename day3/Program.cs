using Common;
using System;
using System.Linq;

namespace day3
{
    class Program
    {

        static readonly InputFetcher inputFetcher = new InputFetcher();
        static int x = 0;
        static int y = 0;
        static int treesEncountered=0;
        static  int maxWidth;
        static char treeIndicator ='#';
        static void Main(string[] args)
        {
            Console.WriteLine("Good morning World!");


            var originalInput = inputFetcher.GetInput(InputFetcher.day3p1);
            maxWidth = originalInput[0].Length;
           while(y < originalInput.Length-1)
            {
                MoveForward();
                var line = originalInput[y];
                var chararray = line.ToCharArray();
                var detected = chararray[x];
                if(detected== treeIndicator)
                {
                    treesEncountered++;
                }
            }
            Console.WriteLine($"Trees: {treesEncountered}. OpenSlopes: {originalInput.Length-1 - treesEncountered}");
            Console.WriteLine("Done");
        }

        private static void MoveForward()
        {
            var proposedX = x + 3;
            if (proposedX >= maxWidth)
            {
                x = proposedX - maxWidth;
            }
            else
            {
                x += 3;
            }
            
            y += 1;
        }
    }
}
