using System.Collections.Generic;
using System.Linq;
using SWAPI.Library.Models;
using SWAPI.Library.Settings;

namespace SWAPI.Library.DataAccess
{
    public class PersonManager
    {
        private ISettingsManager _settingsManager;

        private string DataSource => _settingsManager.GetItemAsString("dataSource");

        public PersonManager(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        public void SaveMany(List<Person> people)
        {
            using (var db = new SWAPIContext(DataSource))
            {
                db.People.AddRange(people);
                db.SaveChanges();
            }
        }

        public List<Person> GetAll()
        {
            using(var db = new SWAPIContext(DataSource))
            {
                return db.People.ToList();
            }
        }
    }
}
