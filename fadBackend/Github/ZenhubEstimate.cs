using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace fad2.Backend
{
    public class ZenhubEstimate
    {
        [JsonProperty(PropertyName = "value")]
        public  int Value { get; set; }
    }
}
