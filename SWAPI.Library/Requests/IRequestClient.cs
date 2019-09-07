using System.Threading.Tasks;

namespace SWAPI.Library.Requests
{
    public interface IRequestClient
    {
        Task<string> GetAsync(string requestUrl);
    }
}
