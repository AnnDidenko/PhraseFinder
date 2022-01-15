using HtmlAgilityPack;
using Phrase_Finder.Application.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Services
{
    public class VideoScrappingService : IVideoScrappingService
    {
        private readonly ITEDApi _tedApi;

        public VideoScrappingService(ITEDApi tedApi)
        {
            _tedApi = tedApi;
        }
        public async Task<List<string>> GetVideoLinks(int page)
        {
            string document = await _tedApi.GetListOfVideosHtml(page);

            HtmlDocument htmlSnippet = new HtmlDocument();
            htmlSnippet.LoadHtml(document);

            HtmlNodeCollection htmlNodes = htmlSnippet.DocumentNode.SelectNodes("//div[@class='talk-link']/div/div/a");
            List<string> hrefTags = new List<string>();

            foreach (HtmlNode link in htmlNodes)
            {
                HtmlAttribute att = link.Attributes["href"];
                hrefTags.Add(att.Value);
            }
            return hrefTags;
        }

        public async Task<int> GetPageCount(int page)
        {
            string document = await _tedApi.GetListOfVideosHtml(page);

            HtmlDocument htmlSnippet = new HtmlDocument();
            htmlSnippet.LoadHtml(document);

            var documentNode = htmlSnippet.DocumentNode.SelectSingleNode("//div[@class='results__pagination']/div/a[last()-1]");
            string innerText = documentNode.InnerText;
            var pageCount = Int32.Parse(innerText);

            return pageCount;
        }

        public async Task<HtmlDocument> GetVideoTranscriptHtml(string path, string language)
        {
            string document = await _tedApi.GetVideoTranscriptHtml(path, language);

            HtmlDocument htmlSnippet = new HtmlDocument();
            htmlSnippet.LoadHtml(document);

            return htmlSnippet;
        }

        public string GetVideoName(HtmlDocument document)
        {
            HtmlNode htmlNode = document.DocumentNode.SelectSingleNode("//meta[@itemprop='name']");

            return htmlNode.GetAttributeValue("content", string.Empty);
        }

        public string GetVideoSubtitles(HtmlDocument document)
        {
            HtmlNodeCollection htmlNodes = document.DocumentNode.SelectNodes("//div[@class='Grid Grid--with-gutter d:f@md p-b:4']/div/p");
            StringBuilder transcript = new StringBuilder();

            foreach (HtmlNode node in htmlNodes)
            {
                transcript.Append(node.InnerText);
            }

            return FormatText(transcript);
        }

        public string GetYoutubeVideoId(HtmlDocument document)
        {
            HtmlNode htmlNode = document.DocumentNode.SelectSingleNode("//script[@data-spec=\"q\"]");
            string script = htmlNode.InnerText;
            string codeField = "\"YouTube\",\"code\":\"";

            string videoId = Regex.Match(script, $"{codeField}\\w*").ToString();

            if (!string.IsNullOrEmpty(videoId))
            {
                return videoId.Replace(codeField, "");
            }
            else
            {
                return null;
            }
        }

        private string FormatText(StringBuilder text)
        {
            text.Replace("&#39;", "'");
            text.Replace("&quot;", "\"");
            text.Replace("\t", "");
            text.Replace("\n", " ");

            return text.ToString();
        }
    }
}
