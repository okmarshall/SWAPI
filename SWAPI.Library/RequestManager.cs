using System;
using System.Net.Http;
using System.Threading.Tasks;
using SWAPI.Library.Settings;

namespace SWAPI.Library
{
    public class RequestManager
    {
        private ISettingsManager _settingsManager;
        private HttpClient _httpClient;

        public RequestManager(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
            _httpClient = CreateHttpClient();
        }

        public Task<string> MakeRequest()
        {
            return _httpClient.GetStringAsync("people/1");
        }

        private HttpClient CreateHttpClient()
        {
            var baseUrl = _settingsManager.GetItemAsString("baseUrl");

            return new HttpClient { BaseAddress = new Uri(baseUrl) };
        }
    }
}
