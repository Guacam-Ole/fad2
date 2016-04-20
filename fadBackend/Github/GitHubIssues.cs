using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace fad2.Backend.Github
{
    /// <summary>
    /// A single Issue on Github
    /// </summary>
    public class GitHubIssue
    {
        /// <summary>
        /// Issue-Number
        /// </summary>
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Url from Repository
        /// </summary>
        [JsonProperty(PropertyName = "repository_url")]
        public string RepositoryUrl { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// User who created that issue
        /// </summary>
        [JsonProperty(PropertyName = "user")]
        public GitHubUser User { get; set; }

        /// <summary>
        /// Labels used in this issue
        /// </summary>
        [JsonProperty(PropertyName = "labels")]
        public List<GitHubLabel> Labels { get; set; }

        /// <summary>
        /// Current state of that issue
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        /// <summary>
        /// Creationdate
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Main content of the issue
        /// </summary>
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        /// <summary>
        /// Comments to that issue
        /// </summary>
        [JsonProperty(PropertyName = "comments")]
        public int CommentCount { get; set; }

        /// <summary>
        /// Url for the comments
        /// </summary>
        [JsonProperty(PropertyName = "comments_url")]
        public string CommentsUrl { get; set; }

        /// <summary>
        /// Non-Api-Url
        /// </summary>
        [JsonProperty(PropertyName = "html_url")]
        public string HtmlUrl { get; set; }

        /// <summary>
        /// According Issue from Zenhub
        /// </summary>
        public ZenhubIssue ZenhubIssue { get; set; }

        /// <summary>
        /// Comments
        /// </summary>
        public List<GitHubIssue> Comments { get; set; }

        /// <summary>
        /// Is this a bug?
        /// </summary>
        public bool IsBug { get; set; }
        /// <summary>
        /// Is this an enhancement?
        /// </summary>
        public bool IsWish { get; set; }
        /// <summary>
        /// Zenhub-Pipeline from this issue
        /// </summary>
        public string Pipeline { get; set; }

        /// <summary>
        /// Return issue as comment
        /// </summary>
        public GitHubComment Comment => new GitHubComment
        {
            Url = HtmlUrl,
            Author = User?.Name,
            Picture = User?.Avatar,
            Title = Title,
            Comment = Body,
            Date = CreatedAt
        };
    }
}