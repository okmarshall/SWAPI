using System.Threading.Tasks;
using SWAPI.Library.Enums;
using SWAPI.Library.Models;

namespace SWAPI.Library.Requests
{
    public interface IRequestManager
    {
        Task<T> GetById<T>(Resource resource, int id) where T : BaseModel;
    }
}
