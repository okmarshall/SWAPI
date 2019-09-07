using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

        public async Task<T> GetById<T>(string endpoint, int id) where T : BaseModel
        {
            var result = await _client.GetAsync($"{ endpoint }/{ id }");

            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<List<T>> GetAll<T>(string endpoint) where T : BaseModel
        {
            var results = new List<T>();

            var next = string.Empty;

            while (next != null)
            {
                var response = await _client.GetAsync(endpoint);

                var resultPage = JsonConvert.DeserializeObject<ResultPage<T>>(response);

                foreach (var result in resultPage.Results)
                {
                    results.Add(result);
                }

                next = resultPage.Next;

                endpoint = next;
            }

            return results;
        }
    }
}
