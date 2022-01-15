using Microsoft.EntityFrameworkCore;
using Phrase_Finder.Domain.Entities;
using Phrase_Finder.Domain.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phrase_Finder.Domain.Repositories
{
    public class VideosRepository : IVideosRepository
    {
        private ApplicationContext _context;

        public VideosRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddVideo(Video video)
        {
            await _context.Videos.AddAsync(video);
            await _context.SaveChangesAsync();
        }

        public void DeleteVideo(Video video)
        {
            _context.Videos.Remove(video);
            _context.SaveChanges();
        }

        public IEnumerable<Video> GetAllVideos()
        {
            return _context.Videos.AsNoTracking();
        }

        public void UpdateVideo(Video video)
        {
            _context.Videos.Update(video);
            _context.SaveChanges();
        }
    }
}
