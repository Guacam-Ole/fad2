﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace fad2.Backend
{
    public class GitHubIssue
    {
        [JsonProperty(PropertyName = "number")]
        public  int Number { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "repository_url")]
        public string RepositoryUrl { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "user")]
        public GitHubUser User { get; set; }

        [JsonProperty(PropertyName = "labels")]
        public List<GitHubLabel> Labels { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "comments")]
        public int CommentCount { get; set; }

        [JsonProperty(PropertyName = "comments_url")]
        public string CommentsUrl { get; set; }

        [JsonProperty(PropertyName = "html_url")]
        public string HtmlUrl { get; set; }

        public ZenhubIssue ZenhubIssue { get; set; }

        public List<GitHubIssue> Comments { get; set; }

        public bool IsBug { get; set; }
        public bool IsWish { get; set; }
        public string Pipeline { get; set; }

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