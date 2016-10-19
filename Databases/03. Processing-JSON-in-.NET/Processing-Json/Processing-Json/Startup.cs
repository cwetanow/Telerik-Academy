using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Processing_Json
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var path = "../../../youtube-feed.xml";

            DownloadFile(path);

            var doc = XDocument.Load(path);

            var json = ParseToJson(doc);

            var videos = GetVideoObjects(json);

            PrintVideoTitles(videos);

            var filePath = "../../../index.html";

            GenerateHtml(videos, filePath);
        }

        public static void GenerateHtml(IJEnumerable<JToken> videos, string filePath)
        {
            var pocos = videos.Select(x => new
            {
                Title = x["title"],
                Link = x["media:group"]["media:content"]["@url"]
            });

            var html = new Collection<string>();

            var start = "<html><body><div>";
            var end = "</div></body></html>";

            html.Add(start);
            foreach (var poco in pocos)
            {
                var line = $"<iframe src=\"{poco.Link}\"></iframe><hr/>";
                html.Add(line);
            };

            html.Add(end);

            File.WriteAllLines(filePath, html);
        }

        public static IJEnumerable<JToken> GetVideoObjects(string json)
        {
            var videoObjects = JObject.Parse(json)["feed"]["entry"].Children();

            return videoObjects;
        }

        public static void PrintVideoTitles(IJEnumerable<JToken> videos)
        {
            foreach (var video in videos)
            {
                var title = video["title"];

                Console.WriteLine(title);
                Console.WriteLine();
            }
        }

        public static string ParseToJson(XDocument doc)
        {
            var json = JsonConvert.SerializeXNode(doc, Formatting.Indented);

            return json;
        }

        public static void DownloadFile(string filePath)
        {
            var feedLink = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";

            var client = new WebClient();
            client.DownloadFile(feedLink, filePath);
        }
    }
}
