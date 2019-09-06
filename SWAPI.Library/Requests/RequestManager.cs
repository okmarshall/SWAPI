using System;
using System.Net.Http;
using System.Threading.Tasks;
using SWAPI.Library.Settings;
using SWAPI.Library.Enums;

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
