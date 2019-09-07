using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SWAPI.Library.Models;
using SWAPI.Library.Settings;

namespace SWAPI.Library.DataAccess
{
    public class PersonManager : IPersonManager
    {
        private ISettingsManager _settingsManager;

        private string DataSource => _settingsManager.GetItemAsString("dataSource");

        public PersonManager(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        public Task<int> SaveMany(List<Person> people)
        {
            using (var dbContext = new SWAPIContext(DataSource))
            {
                foreach (var person in people)
                {
                    if(!dbContext.People.Any(p => p.Name == person.Name))
                    {
                        dbContext.People.Add(person);
                    }
                }

                return dbContext.SaveChangesAsync();
            }
        }

        public List<Person> GetAll()
        {
            using(var dbContext = new SWAPIContext(DataSource))
            {
                return dbContext.People.ToList();
            }
        }
    }
}
