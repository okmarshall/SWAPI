using System;
using System.Threading.Tasks;
using SWAPI.Library;
using SWAPI.Library.Models;
using SWAPI.Library.Settings;
using Newtonsoft.Json;

namespace SWAPI.UI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var requestManager = new RequestManager(new SettingsManager());

            var result = await requestManager.MakeRequest();

            var person = JsonConvert.DeserializeObject<Person>(result);

            Console.WriteLine($"Name: {person.Name}, Vehicles: {string.Join(",", person.Vehicles)}");
        }
    }
}
