using System;
using System.Linq;
using System.Threading.Tasks;
using SWAPI.Library.DataAccess;
using SWAPI.Library.Models;
using SWAPI.Library.Requests;
using SWAPI.Library.Settings;

namespace SWAPI.UI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var requestManager = new RequestManager(new RequestClient(new SettingsManager()));


            //var people = await requestManager.GetAll<Person>("people");

            //var personManager = new PersonManager();

            //personManager.SaveMany(people);

            //foreach (var person in personManager.GetAll())
            //{
            //    Console.WriteLine(person.Name);
            //}

            var person = new PersonManager(new SettingsManager()).GetAll().First();

            Console.WriteLine(person.Name);
        }
    }
}
