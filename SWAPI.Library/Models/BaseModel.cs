using Newtonsoft.Json;

namespace SWAPI.Library.Models
{
    public abstract class BaseModel
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("edited")]
        public string Edited { get; set; }
    }
}
