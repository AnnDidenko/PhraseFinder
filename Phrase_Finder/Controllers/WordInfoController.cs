using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Phrase_Finder.Application.Infrastructure;
using Phrase_Finder.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phrase_Finder.Controllers
{
    public class WordInfoController : ControllerBase
    {
        private readonly IWordInfoService _wordInfoService;
        private readonly IVideoScrappingService _videoScrapping;
        private readonly IVideosService _videosService;

        public WordInfoController(IWordInfoService wordInfoService, IVideoScrappingService videoScrapping, IVideosService videosService)
        {
            _wordInfoService = wordInfoService;
            _videoScrapping = videoScrapping;
            _videosService = videosService;
        }

        [HttpGet("lemma")]
        public async Task<string> GetLemma([FromQuery] string word)
        {
            var res = await _wordInfoService.GetLemmas(word);
            var jsonoutPut = JsonConvert.SerializeObject(res);
            return jsonoutPut;
        }

        [HttpGet("videoLinks")]
        public async Task<List<string>> GetLinks([FromQuery] int page)
        {
            var res = await _videoScrapping.GetVideoLinks(page);

            return res;
        }

        [HttpGet("addVideo")]
        public async Task AddVideo([FromQuery] string language, [FromQuery] int page, [FromQuery] int id)
        {
            var links = await _videoScrapping.GetVideoLinks(page);

            VideoDto video = new VideoDto();
            HtmlDocument doc = await _videoScrapping.GetVideoTranscriptHtml(links[id-1], language);

            video.Name = _videoScrapping.GetVideoName(doc);
            video.Subtitles = _videoScrapping.GetVideoSubtitles(doc);
            video.YouTubeVideoId = _videoScrapping.GetYoutubeVideoId(doc);
            video.Url = links[id-1];

            await _videosService.AddVideo(video);
        }

        [HttpGet("videoId")]
        public async Task<string> GetVideoId([FromQuery] string language, [FromQuery] int page, [FromQuery] int id)
        {
            var links = await _videoScrapping.GetVideoLinks(page);

            var res = _videoScrapping.GetYoutubeVideoId(await _videoScrapping.GetVideoTranscriptHtml(links[id], language));

            return res;
        }

        [HttpGet("inflections")]
        public async Task<string> GetInflections([FromQuery] string word)
        {
            var res = await _wordInfoService.GetWordInflections(word);
            var jsonoutPut = JsonConvert.SerializeObject(res);
            return jsonoutPut;
        }
    }
}
