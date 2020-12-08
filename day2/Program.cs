using Common;
using System;
using System.Linq;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting passsword tests");
            RunPart1();
            RunPart2();
        }

        private static void RunPart1()
        {
            var input = InputFetcher.GetInputAsLines(InputFetcher.day2p1);
            var inputs = input.Select(i => new PasswordInputP1(i));
            var validInputs = inputs.Where(i => i.IsValid());
            var invalidInputs = inputs.Where(i => !i.IsValid());
            Console.WriteLine($"Part 1 - Read {input.Length} inputs. Valid: {validInputs.Count()}. Invalid; {invalidInputs.Count()}");
        }

        private static void RunPart2()
        {
            var input = InputFetcher.GetInputAsLines(InputFetcher.day2p1);
            var inputs = input.Select(i => new PasswordInputP2(i));
            var validInputs = inputs.Where(i => i.IsValid());
            var invalidInputs = inputs.Where(i => !i.IsValid());
            Console.WriteLine($"Part 2 - Read {input.Length} inputs. Valid: {validInputs.Count()}. Invalid; {invalidInputs.Count()}");
        }
    }

    class PasswordInputP1
    {
        private int countMin;
        private int countMax;
        private char charRestriction;
        private string passwinput;


        public PasswordInputP1(string inputstring)
        {
            var inputarray = inputstring.Split(':');
            var restrictionsstring = inputarray[0];
            passwinput = inputarray[1].TrimStart();

            EstablishRestrictions(restrictionsstring);

        }

        private void EstablishRestrictions(string restrictionString)
        {
            var restrictionarray = restrictionString.Split(' ');
            DefineCountLimits(restrictionarray[0]);
            charRestriction = char.Parse(restrictionarray[1]);
        }

        private void DefineCountLimits(string countlimitstring)
        {
            var countstrcut = countlimitstring.Split('-');
            countMin = int.Parse(countstrcut[0]);
            countMax = int.Parse(countstrcut[1]);
        }

        public bool IsValid()
        {
            int count = passwinput.Count(l => l  == charRestriction);
            var valid =  countMin <= count  && count <= countMax;
            return valid;
        }
    }

    class PasswordInputP2
    {
        private int pos1;
        private int pos2;
        private char charRestriction;
        private string passwinput;


        public PasswordInputP2(string inputstring)
        {
            var inputarray = inputstring.Split(':');
            var restrictionsstring = inputarray[0];
            passwinput = inputarray[1].TrimStart();

            EstablishRestrictions(restrictionsstring);

        }

        private void EstablishRestrictions(string restrictionString)
        {
            var restrictionarray = restrictionString.Split(' ');
            DefinePositionalRequirements(restrictionarray[0]);
            charRestriction = char.Parse(restrictionarray[1]);
        }

        private void DefinePositionalRequirements(string countlimitstring)
        {
            var countstrcut = countlimitstring.Split('-');
            pos1 = int.Parse(countstrcut[0]);
            pos2 = int.Parse(countstrcut[1]);
        }

        public bool IsValid()
        {

            var valid = passwinput[pos1-1]==charRestriction ^ passwinput[pos2-1]==charRestriction;
            return valid;
        }
    }
}
