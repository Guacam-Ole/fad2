using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace fad2.Backend
{
    public class ZenhubPipeline
    {
        [JsonProperty(PropertyName = "name")]
        public  string Name { get; set; }
        [JsonProperty(PropertyName = "issues")]
        public  List<ZenhubIssue> Issues { get; set; }
    }
}
