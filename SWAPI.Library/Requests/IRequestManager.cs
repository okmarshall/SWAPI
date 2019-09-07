using System.Collections.Generic;
using System.Threading.Tasks;
using SWAPI.Library.Models;

namespace SWAPI.Library.Requests
{
    public interface IRequestManager
    {
        Task<T> GetById<T>(string endpoint, int id) where T : BaseModel;

        Task<List<T>> GetAll<T>(string endpoint) where T : BaseModel;
    }
}
