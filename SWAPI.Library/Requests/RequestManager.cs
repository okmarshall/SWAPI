using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SWAPI.Library.Enums;
using SWAPI.Library.Models;

namespace SWAPI.Library.Requests
{
    public class RequestManager : IRequestManager
    {
        private readonly IRequestClient _client;

        public RequestManager(IRequestClient requestClient)
        {
            _client = requestClient;
        }

        public async Task<T> GetById<T>(Resource resource, int id) where T : BaseModel
        {
            var url = $"{resource.GetName()}/{id}";

            var result = await _client.GetAsync(url);

            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<List<T>> GetAll<T>(Resource resource) where T : BaseModel
        {
            var url = $"{resource.GetName()}";

            var results = new List<T>();

            var next = string.Empty;

            while (next != null)
            {
                var result = await _client.GetAsync(url);

                var resultPage = JsonConvert.DeserializeObject<ResultPage<T>>(result);

                foreach (var person in resultPage.Results)
                {
                    results.Add(person);
                }

                next = resultPage.Next;

                url = next;
            }

            return results;
        }
    }
}
