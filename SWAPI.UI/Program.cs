using System.Threading.Tasks;
using SWAPI.Library.DataAccess;
using SWAPI.Library.Models;
using SWAPI.Library.Requests;
using SWAPI.Library.Settings;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SWAPI.UI
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static async Task Main(string[] args)
        {
            try
            {
                RegisterServices();

                var requestManager = _serviceProvider.GetService<IRequestManager>();

                Console.WriteLine("Retrieving all people...");

                var people = await requestManager.GetAll<Person>("people");

                if (people?.Count > 0)
                {
                    var personManager = _serviceProvider.GetService<IPersonManager>();

                    Console.WriteLine($"Found { people.Count } people...");

                    var count = await personManager.SaveMany(people);

                    Console.WriteLine($"Persisted { count } people...");
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

        public static void RegisterServices()
        {
            _serviceProvider = new ServiceCollection()
                .AddTransient<IRequestManager, RequestManager>()
                .AddSingleton<IRequestClient, RequestClient>()
                .AddSingleton<ISettingsManager, SettingsManager>()
                .AddSingleton<IPersonManager, PersonManager>()               
                .BuildServiceProvider();
        }
    }
}
