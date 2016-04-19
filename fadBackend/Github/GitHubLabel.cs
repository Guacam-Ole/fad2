using Newtonsoft.Json;

namespace fad2.Backend
{
    public class GitHubLabel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }
    }
}