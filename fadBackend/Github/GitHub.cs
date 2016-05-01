using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace fad2.Backend.Github
{
    /// <summary>
    ///     Github-Methods
    /// </summary>
    public static class GitHub
    {
        private const int CacheDuration = 60;

        private static string GetStringFromUrl(string url)
        {
            using (var wc = new LongRunningWebClient())
            {
                wc.Encoding = Encoding.UTF8;
                wc.Headers.Add("ContentType", "application/json");
                wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.112 Safari/537.36");
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

        private static ZenHubBoard GetCachedBoard(string cacheFileName)
        {
            return (ZenHubBoard) GetCache(cacheFileName, typeof(ZenHubBoard));
        }

        private static List<GitHubIssue> GetCachedIssues(string cacheFileName)
        {
            return (List<GitHubIssue>) GetCache(cacheFileName, typeof(List<GitHubIssue>));
        }

        private static object GetCache(string cacheFileName, Type cacheType)
        {
            if (!File.Exists(cacheFileName)) return null;
            var cacheInfo = new FileInfo(cacheFileName);
            if (!((DateTime.Now - cacheInfo.LastWriteTime).TotalMinutes < CacheDuration)) return null;
            using (var sr = cacheInfo.OpenText())
            {
                var content = string.Empty;
                string singleLine;
                while ((singleLine = sr.ReadLine()) != null)
                {
                    content += singleLine;
                }
                return JsonConvert.DeserializeObject(content, cacheType);
            }
        }

        private static void WriteCachedIssues(string cacheFileName, List<GitHubIssue> issues)
        {
            WriteCache(cacheFileName, issues);
        }

        private static void WriteCachedBoard(string cacheFileName, ZenHubBoard board)
        {
            WriteCache(cacheFileName, board);
        }

        private static void WriteCache(string cacheFileName, object data)
        {
            var cacheInfo = new FileInfo(cacheFileName);
            var stringData = JsonConvert.SerializeObject(data, Formatting.Indented);
            using (var fs = cacheInfo.Create())
            {
                var info = new UTF8Encoding(true).GetBytes(stringData);
                fs.Write(info, 0, info.Length);
                fs.Close();
            }
        }


        private static ZenHubBoard GetBoard(int repoId)
        {
            string zenhubUrl = $"http://files.oles-cloud.de/zenhub.php?repo={repoId}";
            var zenhubContent = GetStringFromUrl(zenhubUrl);
            return JsonConvert.DeserializeObject<ZenHubBoard>(zenhubContent);
        }

        /// <summary>
        /// Get Data from ZenHub board
        /// </summary>
        /// <param name="cacheFileName">local cachefilename</param>
        /// <param name="user">GitHub-User - thats me :) </param>
        /// <param name="repo">Repo</param>
        /// <returns>Zenhub-Board</returns>
        public static ZenHubBoard GetBoard(string cacheFileName, string user, string repo)
        {
            var board = GetCachedBoard(cacheFileName);
            if (board != null)
            {
                return board;
            }
            string repositoryUrl = $"https://api.github.com/repos/{user}/{repo}";
            var repositoryjson = GetStringFromUrl(repositoryUrl);
            var repository = JsonConvert.DeserializeObject<GitHubIssue>(repositoryjson);
            board = GetBoard(repository.Id);
            WriteCachedBoard(cacheFileName, board);
            return board;
        }


        /// <summary>
        ///     Get Issues from Github
        /// </summary>
        /// <param name="cacheFileName">Cachefile</param>
        /// <param name="user">User on Github (that's me :) )</param>
        /// <param name="repo">Repo for fad2</param>
        /// <returns></returns>
        public static List<GitHubIssue> GetIssues(string cacheFileName, string user, string repo)
        {
            var allComments = GetCachedIssues(cacheFileName);
            if (allComments != null)
            {
                return allComments;
            }
            string url = $"https://api.github.com/repos/{user}/{repo}/issues";

            var json = GetStringFromUrl(url);
            var issues = JsonConvert.DeserializeObject<List<GitHubIssue>>(json);
            if (issues == null) return null;
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
            }
            WriteCachedIssues(cacheFileName, issues);
            return issues;
        }
    }
}