using System.Collections.Generic;
using System.Threading.Tasks;
using SWAPI.Library.Models;

namespace SWAPI.Library.DataAccess
{
    public interface IPersonManager
    {
        Task<int> SaveMany(List<Person> people);

        List<Person> GetAll();
    }
}
