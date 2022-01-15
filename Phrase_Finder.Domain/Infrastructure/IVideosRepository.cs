using Phrase_Finder.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phrase_Finder.Domain.Infrastructure
{
    public interface IVideosRepository
    {
        IEnumerable<Video> GetAllVideos();
        Task AddVideo(Video video);
        void UpdateVideo(Video video);
        void DeleteVideo(Video video);
    }
}
