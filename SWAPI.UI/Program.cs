using System;
using System.Threading.Tasks;
using SWAPI.Library;
using SWAPI.Library.Settings;

namespace SWAPI.UI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var requestManager = new RequestManager(new SettingsManager());

            var result = await requestManager.MakeRequest();

            Console.WriteLine(result);
        }
    }
}
