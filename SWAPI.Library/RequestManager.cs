using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SWAPI.Library
{
    public class RequestManager
    {
        public async Task<string> MakeRequest()
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://swapi.co/api/");

            var response = await httpClient.GetAsync("planets/1");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
