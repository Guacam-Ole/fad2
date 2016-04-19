using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace fad2.Backend.Github
{
    public class ZenhubPlus1
    {
        [JsonProperty(PropertyName = "user_id")]
        public  int UserId { get; set; }
        [JsonProperty(PropertyName = "created_at")]
        public  DateTime CreatedAt { get; set; }
    }
}
