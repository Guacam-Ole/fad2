using System.Collections.Generic;
using Newtonsoft.Json;

namespace fad2.Backend.Github
{
    /// <summary>
    /// Zenhub - Boardinfo for Github Repo
    /// </summary>
    public class ZenHubBoard
    {
        /// <summary>
        /// Pipelines in that board
        /// </summary>
        [JsonProperty(PropertyName = "pipelines")]
        public List<ZenhubPipeline> Pipelines { get; set; }
    }
}