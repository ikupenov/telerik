using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProcessingJSON.Models;
using ProcessingJSON.Utils;

namespace ProcessingJSON
{
    internal class StartUp
    {
        private const string RssFeedUrl =
            @"https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";

        private static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var downloadDirectory = Directory.GetCurrentDirectory() + @"\..\..\file.xml";

            var downloadManager = new WebClientDownloadManager();
            downloadManager.DownloadFile(RssFeedUrl, downloadDirectory);

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(downloadDirectory);

            var jsonRss = JsonConvert.SerializeXmlNode(xmlDoc);
            var jsonObj = JObject.Parse(jsonRss);

            var videoTitles = jsonObj.Descendants()
                .OfType<JProperty>()
                .Where(x => x.Name.ToLower() == "title")
                .Select(x => x.Value);

            foreach (var videoTitle in videoTitles)
            {
                Console.WriteLine(videoTitle);
            }

            IEnumerable<Video> videos = jsonObj["feed"]["entry"]
                .Select(x => JsonConvert.DeserializeObject<Video>(x.ToString()));

            var htmlDirectory = Directory.GetCurrentDirectory() + @"\..\..\index.html";
            HtmlConverter.CreateHtml(htmlDirectory, videos);
        }
    }
}
