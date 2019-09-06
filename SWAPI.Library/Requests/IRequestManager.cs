using System.Threading.Tasks;
using SWAPI.Library.Enums;

namespace SWAPI.Library.Requests
{
    public interface IRequestManager
    {
        Task<string> GetById(Resource resource, int id);
    }
}
