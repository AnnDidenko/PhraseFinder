using Phrase_Finder.Domain.Entities;
using Phrase_Finder.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phrase_Finder.Domain.Repositories
{
    public class TranslationalWordRepository : ITranslationalWordRepository
    {
        private ApplicationContext _context;

        public TranslationalWordRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Add(TranslationalWord word)
        {
            await _context.TranslationalWords.AddAsync(word);
            await _context.SaveChangesAsync();
        }

        public void Delete(TranslationalWord word)
        {
            _context.TranslationalWords.Remove(word);
        }

        public IEnumerable<TranslationalWord> GetAll()
        {
            return _context.TranslationalWords;
        }

        public TranslationalWord GetById(int id)
        {
            return _context.TranslationalWords.FirstOrDefault(w => w.Id == id);
        }

        public void Update(TranslationalWord word)
        {
            _context.TranslationalWords.Update(word);
            _context.SaveChanges();
        }
    }
}
