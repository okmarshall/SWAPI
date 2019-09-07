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
            var requestManager = new RequestManager(new RequestClient(new SettingsManager()));

            //var person = await requestManager.GetById<Person>(Resource.People, 1);

            var people = await requestManager.GetAll<Person>(Resource.People);

            foreach (var person in people)
            {
                Console.WriteLine(person.Name);
            }
        }
    }
}
