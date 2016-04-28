using System.Collections.Generic;
using Newtonsoft.Json;

namespace fad2.Backend.Github
{
    /// <summary>
    ///     Single Pipelin in Zenhub
    /// </summary>
    public class ZenhubPipeline
    {
        /// <summary>
        ///     Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///     Issues
        /// </summary>
        [JsonProperty(PropertyName = "issues")]
        public List<ZenhubIssue> Issues { get; set; }
    }
}