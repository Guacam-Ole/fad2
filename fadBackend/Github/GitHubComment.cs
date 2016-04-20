using System;

namespace fad2.Backend.Github
{
    /// <summary>
    /// A single Comment on a github issue
    /// </summary>
    public class GitHubComment
    {
        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Autjhor
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Author-Picture
        /// </summary>
        public string Picture { get; set; }
        /// <summary>
        /// Title from Comment (only on first comment)
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The comment itself
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// Date posted
        /// </summary>
        public DateTime Date { get; set; }
    }
}