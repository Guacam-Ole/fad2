using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace fad2.Backend
{
    public static class GitHub
    {
        private static string GetStringFromUrl(string url)
        {
            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add("ContentType", "application/json");
                wc.Headers.Add("User-Agent",
                    "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.112 Safari/537.36");
                return wc.DownloadString(url);
            }
        }

        private static GitHubUser GetUserFromUrl(string url)
        {
            var jsonUser = GetStringFromUrl(url);
            var user = JsonConvert.DeserializeObject<GitHubUser>(jsonUser);
            if (user.Name == null)
            {
                user.Name = user.Login;
            }
            return user;
        }

        private static List<GitHubIssue> GetCachedIssues(string cacheFileName)
        {
            if (File.Exists(cacheFileName))
            {
                var cacheInfo = new FileInfo(cacheFileName);
                if ((DateTime.Now - cacheInfo.LastWriteTime).TotalMinutes < 90)
                {
                    using (var sr = cacheInfo.OpenText())
                    {
                        var githubContent = string.Empty;
                        string singleLine;
                        while ((singleLine = sr.ReadLine()) != null)
                        {
                            githubContent += singleLine;
                        }
                        return JsonConvert.DeserializeObject<List<GitHubIssue>>(githubContent);
                    }
                }
            }
            return null;
        }

        public static void WriteCachedIssues(string cacheFileName, List<GitHubIssue> issues)
        {
            var cacheInfo = new FileInfo(cacheFileName);
            var stringData = JsonConvert.SerializeObject(issues, Formatting.Indented);
            using (var fs = cacheInfo.Create())
            {
                var info = new UTF8Encoding(true).GetBytes(stringData);
                fs.Write(info, 0, info.Length);
                fs.Close();
            }
        }

        public static List<GitHubIssue> GetIssues(string cacheFileName, string user, string repo, bool useZenhub = false)
        {
            var allComments = GetCachedIssues(cacheFileName);
            if (allComments != null)
            {
                return allComments;
            }
            string url = $"https://api.github.com/repos/{user}/{repo}/issues";

            var json = GetStringFromUrl(url);
            var issues = JsonConvert.DeserializeObject<List<GitHubIssue>>(json);
            if (issues != null)
            {
                foreach (var issue in issues)
                {
                    issue.User = GetUserFromUrl(issue.User.Url);

                    if (issue.CommentCount > 0)
                    {
                        var jsonComments = GetStringFromUrl(issue.CommentsUrl);
                        issue.Comments = JsonConvert.DeserializeObject<List<GitHubIssue>>(jsonComments);
                        if (issue.Comments != null)
                        {
                            foreach (var comment in issue.Comments)
                            {
                                comment.User = GetUserFromUrl(comment.User.Url);
                            }
                        }
                    }

                    issue.IsBug = issue.Labels.Any(lb => lb.Name == "bug");
                    issue.IsWish = issue.Labels.Any(lb => lb.Name == "enhancement");

                    if (issue.Labels.Any(lb => lb.Name == "Closed"))
                    {
                        issue.Pipeline = "Closed";
                    }
                    else if (issue.Labels.Any(lb => lb.Name == "Done"))
                    {
                        issue.Pipeline = "Done";
                    }
                    else if (issue.Labels.Any(lb => lb.Name == "In Progress"))
                    {
                        issue.Pipeline = "In Progress";
                    }
                    else if (issue.Labels.Any(lb => lb.Name == "ToDo"))
                    {
                        issue.Pipeline = "ToDo";
                    }
                    else
                    {
                        issue.Pipeline = "New";
                    }
                }
                WriteCachedIssues(cacheFileName, issues);
                return issues;
            }

            return null;
        }
    }
}