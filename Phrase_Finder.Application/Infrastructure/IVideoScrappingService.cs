using HtmlAgilityPack;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Infrastructure
{
    public interface IVideoScrappingService
    {
        Task<List<string>> GetVideoLinks(int page);
        Task<int> GetPageCount(int page);
        Task<HtmlDocument> GetVideoTranscriptHtml(string path, string language);
        string GetVideoName(HtmlDocument document);
        string GetVideoSubtitles(HtmlDocument document);
        string GetYoutubeVideoId(HtmlDocument document);
    }
}
