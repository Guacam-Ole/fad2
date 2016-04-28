using System.Collections.Generic;
using Newtonsoft.Json;

namespace fad2.Backend.Github
{
    /// <summary>
    ///     Single Issue on Zenhub board
    /// </summary>
    public class ZenhubIssue
    {
        /// <summary>
        ///     +1 for that issue
        /// </summary>
        [JsonProperty(PropertyName = "plus_ones")]
        public List<ZenhubPlus1> PlusOnes { get; set; }

        /// <summary>
        ///     Pipeline for that issue
        /// </summary>
        [JsonProperty(PropertyName = "pipeline")]
        public ZenhubPipeline Pipeline { get; set; }

        /// <summary>
        ///     Estimated time
        /// </summary>
        [JsonProperty(PropertyName = "estimate")]
        public ZenhubEstimate Estimate { get; set; }

        /// <summary>
        ///     vertical position in board
        /// </summary>
        [JsonProperty(PropertyName = "position")]
        public int Position { get; set; }

        /// <summary>
        ///     Issue-number (from github)
        /// </summary>
        [JsonProperty(PropertyName = "issue_number")]
        public int Number { get; set; }
    }
}