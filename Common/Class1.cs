using System.Net.Http;
using System.Threading.Tasks;

namespace Common
{
    public class InputFetcher
    {
        readonly string baseurlFormat = "https://adventofcode.com/2020/day/{0}/input";
        readonly HttpClient client = new HttpClient();
       
        public  async Task<string> GetInput(int day)
        {
            string url = string.Format(baseurlFormat, day);
            var result = await client.GetStringAsync((url);
            return result;
        }
    }
}
