using Microsoft.EntityFrameworkCore;
using Phrase_Finder.Domain.Entities;
using Phrase_Finder.Domain.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phrase_Finder.Domain.Repositories
{
    public class DictionaryRepository : IDictionaryRepository
    {
        private ApplicationContext _context;

        public DictionaryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Add(Dictionary dictionary)
        {
            await _context.Dictionaries.AddAsync(dictionary);
            await _context.SaveChangesAsync();
        }

        public void Delete(Dictionary dictionary)
        {
            _context.Dictionaries.Remove(dictionary);
        }

        public IEnumerable<Dictionary> GetAll()
        {
            return _context.Dictionaries;
        }

        public Dictionary GetById(int id)
        {
            return _context.Dictionaries.FirstOrDefault(d => d.Id == id);
        }

        public Dictionary GetDictionaryByUserId(int id)
        {
            return _context.Dictionaries
                .Include(d => d.Translations)
                .ThenInclude(t => t.TranslationalWords)
                .Where(d => d.UserId == id)
                .FirstOrDefault();
        }

        public void Update(Dictionary dictionary)
        {
            _context.Dictionaries.Update(dictionary);
            _context.SaveChanges();
        }
    }
}
