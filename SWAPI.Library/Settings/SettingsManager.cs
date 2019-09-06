using Microsoft.Extensions.Configuration;

namespace SWAPI.Library.Settings
{
    public class SettingsManager : ISettingsManager
    {
        private IConfiguration _configuration;

        private IConfiguration Configuration
        {
            get
            {
                if(_configuration == null)
                {
                    _configuration = CreateConfiguration();
                }

                return _configuration;
            }
        }

        public string GetItemAsString(string key)
        {
            return Configuration[key];
        }

        private IConfiguration CreateConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
