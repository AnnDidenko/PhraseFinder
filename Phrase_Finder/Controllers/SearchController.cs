using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Phrase_Finder.Application.Infrastructure;
using Phrase_Finder.Application.Models;
using Phrase_Finder.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phrase_Finder.Controllers
{
    public class SearchController : ControllerBase
    {
        private IVideoSearchService _searchService;
        private IMapper _mapper;

        public SearchController(IVideoSearchService searchService,
                                IMapper mapper)
        {
            _searchService = searchService;
            _mapper = mapper;
        }

        [HttpGet("videosByWords")]
        public async Task<string> GetVideoByWords([FromQuery] string[] words)
        {
            var videos = await _searchService.Search(words);
            return JsonConvert.SerializeObject(videos.ToArray(), Formatting.Indented);
        }
    }
}
