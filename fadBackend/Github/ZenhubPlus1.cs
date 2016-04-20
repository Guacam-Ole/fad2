using System;
using Newtonsoft.Json;

namespace fad2.Backend.Github
{
    /// <summary>
    /// +1 Details for Issue
    /// </summary>
    public class ZenhubPlus1
    {
        /// <summary>
        /// User who plussed
        /// </summary>
        [JsonProperty(PropertyName = "user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// CreationDate
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }
    }
}