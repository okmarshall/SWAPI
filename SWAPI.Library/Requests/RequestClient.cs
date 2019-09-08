using System;
using System.Net.Http;
using System.Threading.Tasks;
using SWAPI.Library.Settings;

namespace SWAPI.Library.Requests
{
    public class RequestClient : IRequestClient
    {
        private ISettingsManager _settingsManager;

        private HttpClient _httpClient;

        private HttpClient HttpClient
        {
            get
            {
                if(_httpClient == null)
                {
                    _httpClient = CreateHttpClient();
                }

                return _httpClient;
            }
        }

        public RequestClient(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        public Task<string> GetAsync(string requestUrl)
        {
            return HttpClient.GetStringAsync(requestUrl);
        }

        private HttpClient CreateHttpClient()
        {
            var baseUrl = _settingsManager.GetItemAsString("baseUrl");

            return new HttpClient { BaseAddress = new Uri(baseUrl), Timeout = TimeSpan.FromSeconds(10) };
        }
    }
}
