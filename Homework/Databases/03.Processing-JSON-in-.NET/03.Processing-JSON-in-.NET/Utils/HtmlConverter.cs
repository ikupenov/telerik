using System.Collections.Generic;
using System.IO;
using System.Web.UI;

using ProcessingJSON.Models;

namespace ProcessingJSON.Utils
{
    public static class HtmlConverter
    {
        public static void CreateHtml(string filePath, IEnumerable<Video> videos)
        {
            using (var writer = new StreamWriter(filePath))
            {
                using (var htmlWriter = new HtmlTextWriter(writer, string.Empty))
                {
                    htmlWriter.RenderBeginTag(HtmlTextWriterTag.Html);

                    htmlWriter.RenderBeginTag(HtmlTextWriterTag.Head);
                    htmlWriter.AddAttribute("charset", "utf-8");
                    htmlWriter.RenderBeginTag(HtmlTextWriterTag.Meta);
                    htmlWriter.RenderBeginTag(HtmlTextWriterTag.Title);
                    htmlWriter.Write("YouTube Videos");
                    htmlWriter.RenderEndTag();
                    htmlWriter.RenderEndTag();

                    htmlWriter.WriteLine();

                    htmlWriter.RenderBeginTag(HtmlTextWriterTag.Body);
                    foreach (var video in videos)
                    {
                        htmlWriter.RenderBeginTag(HtmlTextWriterTag.Div);

                        htmlWriter.RenderBeginTag(HtmlTextWriterTag.H3);
                        htmlWriter.Write(video.Title);
                        htmlWriter.RenderEndTag();

                        htmlWriter.WriteLine();

                        htmlWriter.AddAttribute(HtmlTextWriterAttribute.Width, "560px");
                        htmlWriter.AddAttribute(HtmlTextWriterAttribute.Height, "315px");
                        htmlWriter.AddAttribute(HtmlTextWriterAttribute.Src, $"https://www.youtube.com/embed/{video.VideoId}");
                        htmlWriter.AddAttribute("frameborder", "0");
                        htmlWriter.RenderBeginTag("iframe");
                        htmlWriter.RenderEndTag();

                        htmlWriter.RenderEndTag();
                    }
                    htmlWriter.RenderEndTag();

                    htmlWriter.RenderEndTag();
                }
            }
        }
    }
}