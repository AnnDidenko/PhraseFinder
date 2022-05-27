using Phrase_Finder.Domain.Entities;
using System.Collections.Generic;

namespace Phrase_Finder.Domain.Infrastructure
{
    public interface IVideosRepository : IRepository<Video>
    {
        IEnumerable<Video> GetAllByWord(string word);
    }
}
