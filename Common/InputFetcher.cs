using System.Threading.Tasks;

namespace Common
{
    public class InputFetcher
    {
        public static readonly string day2p1 = "day2p1.txt";
        public static readonly string day2p1s1 = "day2p1s1.txt";

        public string[] GetInput(string day)
        {
            return System.IO.File.ReadAllLines(string.Format("input/{0}", day));

        }
    }

    
}
