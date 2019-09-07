using System.Threading.Tasks;
using SWAPI.Library.DataAccess;
using SWAPI.Library.Models;
using SWAPI.Library.Requests;
using SWAPI.Library.Settings;
using System;

namespace SWAPI.UI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var requestManager = new RequestManager(new RequestClient(new SettingsManager()));

                Console.WriteLine("Retrieving all people...");

                var people = await requestManager.GetAll<Person>("people");

                if (people?.Count > 0)
                {
                    var personManager = new PersonManager(new SettingsManager());

                    Console.WriteLine($"Persisting { people.Count } people...");

                    var count = await personManager.SaveMany(people);

                    Console.WriteLine($"Retrieved and persisted { count} people...");
                }
                else
                {
                    Console.WriteLine("No people found...");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong. Exiting...");
            }           
        }
    }
}
