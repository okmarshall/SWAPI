using System;
using System.Threading.Tasks;
using SWAPI.Library;

namespace SWAPI.UI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var requestManager = new RequestManager();

            var result = await requestManager.MakeRequest();

            Console.WriteLine(result);
        }
    }
}
