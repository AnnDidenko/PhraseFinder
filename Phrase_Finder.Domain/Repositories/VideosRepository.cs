using Microsoft.EntityFrameworkCore;
using Phrase_Finder.Domain.Entities;
using Phrase_Finder.Domain.Infrastructure;
using System.Collections.Generic;
using System.Linq;
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
        public async Task Add(Video video)
        {
            await _context.Videos.AddAsync(video);
            await _context.SaveChangesAsync();
        }

        public void Delete(Video video)
        {
            _context.Videos.Remove(video);
            _context.SaveChanges();
        }

        public IEnumerable<Video> GetAll()
        {
            return _context.Videos.AsNoTracking();
        }

        public Video GetById(int id)
        {
            return _context.Videos.FirstOrDefault(v => v.Id == id);
        }

        public IEnumerable<Video> GetAllByWord(string word)
        {
            return _context.Videos
                            .Where(video => video.Subtitles != null)
                            .Where(video => video.Subtitles.ToLower().Contains(word.ToLower()))
                            .AsNoTracking();
        }

        public void Update(Video video)
        {
            _context.Videos.Update(video);
            _context.SaveChanges();
        }
    }
}
