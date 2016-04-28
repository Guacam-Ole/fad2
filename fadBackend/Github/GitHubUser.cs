using Newtonsoft.Json;

namespace fad2.Backend.Github
{
    /// <summary>
    ///     A single Githubuser who posted an issue or comment
    /// </summary>
    public class GitHubUser
    {
        /// <summary>
        ///     Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        ///     Avatar
        /// </summary>
        [JsonProperty(PropertyName = "avatar_url")]
        public string Avatar { get; set; }

        /// <summary>
        ///     Name   (or loginname if missing)
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Url
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        ///     Loginname
        /// </summary>
        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }
    }
}