using Newtonsoft.Json;

namespace fad2.Backend.Github
{
    /// <summary>
    ///     A single Label from Githunb (bug or enhancement)
    /// </summary>
    public class GitHubLabel
    {
        /// <summary>
        ///     Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Backcolor
        /// </summary>
        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }
    }
}