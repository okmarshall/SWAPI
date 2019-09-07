using Newtonsoft.Json;

namespace SWAPI.Library.Models
{
    public class ResultPage<T> where T : BaseModel
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("results")]
        public T[] Results { get; set; }
    }
}
