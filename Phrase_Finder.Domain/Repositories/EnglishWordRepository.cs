using Phrase_Finder.Domain.Entities;
using Phrase_Finder.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phrase_Finder.Domain.Repositories
{
    public class EnglishWordRepository : IEnglishWordRepository
    {
        private ApplicationContext _context;

        public EnglishWordRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Add(EnglishWord word)
        {
            await _context.EnglishWords.AddAsync(word);
            await _context.SaveChangesAsync();
        }

        public void Delete(EnglishWord word)
        {
            _context.EnglishWords.Remove(word);
        }

        public IEnumerable<EnglishWord> GetAll()
        {
            return _context.EnglishWords;
        }

        public EnglishWord GetById(int id)
        {
            return _context.EnglishWords.FirstOrDefault(w => w.Id == id);
        }

        public void Update(EnglishWord word)
        {
            _context.EnglishWords.Update(word);
            _context.SaveChanges();
        }
    }
}
