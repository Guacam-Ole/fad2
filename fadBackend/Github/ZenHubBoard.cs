using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace fad2.Backend.Github
{
    public class ZenHubBoard
    {
        [JsonProperty(PropertyName = "pipelines")]
        public List<ZenhubPipeline> Pipelines { get; set; }
    }
}
