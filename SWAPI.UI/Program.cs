using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SWAPI.Library.Enums;
using SWAPI.Library.Models;
using SWAPI.Library.Requests;
using SWAPI.Library.Settings;

namespace SWAPI.UI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var requestManager = new RequestManager(new SettingsManager());

            var result = await requestManager.GetById(Resource.People, 1);

            var person = JsonConvert.DeserializeObject<Person>(result);

            Console.WriteLine($"Name: {person.Name}, Vehicles: {string.Join(",", person.Vehicles)}");
        }
    }
}
