using Phrase_Finder.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Infrastructure
{
    public interface IVideoSearchService
    {
        Task<Dictionary<VideoDto, string[]>> Search(string[] words);
    }
}
