using Newtonsoft.Json;

namespace fad2.Backend.Github
{
    /// <summary>
    ///     Estimate for that issue
    /// </summary>
    public class ZenhubEstimate
    {
        /// <summary>
        ///     Value of Estimate
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public int Value { get; set; }
    }
}