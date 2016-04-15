using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fad2.UI
{
    public class GitHubComment
    {
        public string Url { get; set; }
        public string Author { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
