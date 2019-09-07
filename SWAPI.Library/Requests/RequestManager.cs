using System;
using System.Net.Http;
using System.Threading.Tasks;
using SWAPI.Library.Settings;
using SWAPI.Library.Enums;
using SWAPI.Library.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

using System.Linq;

namespace SWAPI.Library.Requests
{
    public class RequestManager : IRequestManager
    {
        private readonly ISettingsManager _settingsManager;

        private readonly HttpClient _httpClient;

        public RequestManager(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
            
            _httpClient = CreateHttpClient();
        }

        public Task<string> GetById(Resource resource, int id)
        {
            var url = $"{resource.GetName()}/{id}";

            return Get(url);
        }

        public async Task GetAll(Resource resource)
        {
            var url = $"{resource.GetName()}";

            var people = new List<Person>();

            var next = string.Empty;

            while (next != null)
            {
                var result = await Get(url);

                var resultPage = JsonConvert.DeserializeObject<ResultPage<Person>>(result);

                foreach (var person in resultPage.Results)
                {
                    people.Add(person);
                }

                next = resultPage.Next;

                url = next;
            }
        }

        private Task<string> Get(string requestUrl)
        {
            return _httpClient.GetStringAsync(requestUrl);
        }

        private HttpClient CreateHttpClient()
        {
            var baseUrl = _settingsManager.GetItemAsString("baseUrl");

            return new HttpClient { BaseAddress = new Uri(baseUrl) };
        }
    }
}
