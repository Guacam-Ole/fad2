using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fad2.Backend.Github;
using Newtonsoft.Json;

namespace fad2.Backend
{
    public class ZenhubIssue
    {
        [JsonProperty(PropertyName = "plus_ones")]
        public List<ZenhubPlus1> PlusOnes { get; set; }
        [JsonProperty(PropertyName = "pipeline")]
        public ZenhubPipeline Pipeline { get; set; }
        [JsonProperty(PropertyName = "estimate")]
        public  ZenhubEstimate Estimate { get; set; }
        [JsonProperty(PropertyName = "position")]
        public  int Position { get; set; }
        [JsonProperty(PropertyName = "issue_number")]
        public  int Number { get; set; }
    }
}
