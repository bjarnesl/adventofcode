using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace day3
{
    class Program
    {

        static int x;
        static int xMover;
        static int y;
        static int yMover;
        static uint treesEncountered;
        static List<uint> treesEncounteredCol = new List<uint>();
        static  int maxWidth;
        static char treeIndicator ='#';
        static void Main(string[] args)
        {
            Console.WriteLine("Good morning World!");

            SolvePart1();
            SolvePart2();
            Console.WriteLine("Done");
        }

        private static void SolvePart1()
        {
            var originalInput = InputFetcher.GetInputAsLines(InputFetcher.day3p1);
            maxWidth = originalInput[0].Length;
            treesEncountered = 0;
            x = 0;
            y = 0;
            xMover = 3;
            yMover = 1;
            while (y < originalInput.Length - 1)
            {
                MoveForward();
                var line = originalInput[y];
                var chararray = line.ToCharArray();
                var detected = chararray[x];
                if (detected == treeIndicator)
                {
                    treesEncountered++;
                }
            }
            Console.WriteLine($"Trees: {treesEncountered}. OpenSlopes: {originalInput.Length - 1 - treesEncountered}");
        }

        private static void SolvePart2()
        {
            var originalInput = InputFetcher.GetInputAsLines(InputFetcher.day3p1);
            maxWidth = originalInput[0].Length;
            var possibleMoves = new[]
            {
                new {movex =1, movey=1 },
                new {movex =3, movey=1 },
                new {movex =5, movey=1 },
                new {movex =7, movey=1 },
                new {movex =1, movey=2 }
            };

            foreach (var posmove in possibleMoves)
            {
                treesEncountered = 0;
                x = 0;
                y = 0;
                xMover = posmove.movex;
                yMover = posmove.movey;

                while (y < originalInput.Length - 1)
                {
                    MoveForward();
                    var line = originalInput[y];
                    var chararray = line.ToCharArray();
                    var detected = chararray[x];
                    if (detected == treeIndicator)
                    {
                        treesEncountered++;
                    }
                }
                treesEncounteredCol.Add(treesEncountered);
               
            }
          
            Console.WriteLine($"Trees: {treesEncounteredCol.Aggregate((uint)1,(x,y) => x*y)}. ");
        }

        private static void MoveForward()
        {
            var proposedX = x + xMover;
            if (proposedX >= maxWidth)
            {
                x = proposedX - maxWidth;
            }
            else
            {
                x += xMover;
            }
            
            y += yMover;
        }
    }
}
