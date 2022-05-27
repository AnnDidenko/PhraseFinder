using Phrase_Finder.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Infrastructure
{
    public interface IVideosService
    {
        Task AddVideo(VideoDto videoDto);
        void DeleteVideo(VideoDto videoDto);
        IEnumerable<VideoDto> GetAllVideos();
        void UpdateVideo(VideoDto videoDto);
    }
}
