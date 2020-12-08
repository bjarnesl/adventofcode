using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace day5
{
    class Program
    {

        static void Main(string[] args)
        {
            part1();
            part2();
        }

        private static void part1()
        {
            var input = InputFetcher.GetInputAsLines(InputFetcher.day5p1);
            var maxId = 0;
            foreach (var item in input)
            {
                var inputarray = item.Select(c => c).ToArray();
                var currentMaxRow = 127;
                var currentMinRow = 0;
                var currentMaxSeat = 7;
                var currentMinSeat = 0;
                for (int i = 0; i < 10; i++)
                {
                    
                    var current = inputarray[i];
                    if(current == 'B')
                    {
                        currentMinRow += ((currentMaxRow - currentMinRow)/ 2)+1;
                    }
                    if(current == 'F')
                    {
                        currentMaxRow -=  ((currentMaxRow - currentMinRow+1) / 2);
                    }
                    if(current == 'R')
                    {
                        currentMinSeat += ((currentMaxSeat - currentMinSeat) / 2)+1;
                    }
                    if(current == 'L')
                    {
                        currentMaxSeat -= ((currentMaxSeat - currentMinSeat+1) / 2); 
                    }
                }
                int seatId = (currentMaxRow * 8) +  currentMaxSeat;
                if (seatId > maxId) maxId = seatId;
               
            }
            Console.WriteLine($"max seat id: {maxId}");
           
        }
        private static void part2()
        {
            var input = InputFetcher.GetInputAsLines(InputFetcher.day5p1);
            var maxId = 896;
            var possibleIds = Enumerable.Range(8,888);
            foreach (var item in input)
            {
                var inputarray = item.Select(c => c).ToArray();
                var currentMaxRow = 127;
                var currentMinRow = 0;
                var currentMaxSeat = 7;
                var currentMinSeat = 0;
                for (int i = 0; i < 10; i++)
                {

                    var current = inputarray[i];
                    if (current == 'B')
                    {
                        currentMinRow += ((currentMaxRow - currentMinRow) / 2) + 1;
                    }
                    if (current == 'F')
                    {
                        currentMaxRow -= ((currentMaxRow - currentMinRow + 1) / 2);
                    }
                    if (current == 'R')
                    {
                        currentMinSeat += ((currentMaxSeat - currentMinSeat) / 2) + 1;
                    }
                    if (current == 'L')
                    {
                        currentMaxSeat -= ((currentMaxSeat - currentMinSeat + 1) / 2);
                    }
                }
                int seatId = (currentMaxRow * 8) + currentMaxSeat;
                possibleIds = possibleIds.Where(i => i != seatId);

            }
            Console.WriteLine($"possible seat id: {string.Join(',',possibleIds)}");

        }
    }
}
