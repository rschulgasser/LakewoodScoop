using AngleSharp.Html.Parser;
using System.Collections.Generic;
using System.Net.Http;

namespace LakewoodScoopScraper.Data
{
    public static class LakewoodScoopS
    {
        public static List<NewsItem> Scrape()
        {
            var html = GetLakewoodScoopHtml();
            return ParseLakewoodScoopHtml(html);
        }

        private static List<NewsItem> ParseLakewoodScoopHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            var resultDivs = document.QuerySelectorAll(".post");
            var items = new List<NewsItem>();
            foreach (var div in resultDivs)
            {
                var item = new NewsItem();
                var titleSpan = div.QuerySelector("h2");
                //if (titleSpan == null)
                //{
                //    continue;
                //}
                if (titleSpan != null)
                {
                    item.Title = titleSpan.TextContent;
                }

                var comments = div.QuerySelector(".backtotop");
                if (comments != null)
                {
                    item.NumberOfComments = comments.TextContent;
                }

                var imageTag = div.QuerySelector(".aligncenter");
                if (imageTag != null)
                {
                    item.Image = imageTag.Attributes["src"].Value;
                }

                var linkTag = div.QuerySelector("a");
                if (linkTag != null)
                {
                    item.Link = $"{linkTag.Attributes["href"].Value}";
                }
                var text = div.QuerySelector("p");
                if (text != null)
                {
                    item.Text = text.TextContent;
                }


                items.Add(item);
            }

            return items;
        }

        private static string GetLakewoodScoopHtml()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
            };
            using var client = new HttpClient(handler);
            var url = $"https://www.thelakewoodscoop.com";
            var html = client.GetStringAsync(url).Result;
            return html;
        }
    }
}
