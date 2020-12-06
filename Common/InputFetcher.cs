using System.Threading.Tasks;

namespace Common
{
    public class InputFetcher
    {
        public static readonly string day2p1 = "day2p1.txt";
        public static readonly string day2p1s1 = "day2p1s1.txt";
        public static readonly string day3p1 = "day3p1.txt";
        public static readonly string day3p1s1 = "day3p1s1.txt";
        public static readonly string day4p1 = "day4p1.txt";
        public static readonly string day4p1s1 = "day4p1s1.txt";
        public static readonly string day4p1s2 = "day4p1s2.txt";
        public static readonly string day4p1s3 = "day4p1s3.txt";
        public static readonly string day5p1s1 = "day5p1s1.txt";
        public static readonly string day5p1 = "day5p1.txt";

        public string[] GetInputAsLines(string day)
        {
            return System.IO.File.ReadAllLines(string.Format("input/{0}", day));

        }

        public string GetInputAsString(string day)
        {
            return System.IO.File.ReadAllText(string.Format("input/{0}", day));

        }
    }

    
}
