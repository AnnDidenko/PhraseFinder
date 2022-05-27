using Phrase_Finder.Domain.Entities;
using Phrase_Finder.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phrase_Finder.Domain.Repositories
{
    public class TranslationRepository: ITranslationRepository
    {
        private ApplicationContext _context;

        public TranslationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Add(Translation translation)
        {
            await _context.Translations.AddAsync(translation);
            await _context.SaveChangesAsync();
        }

        public void Delete(Translation translation)
        {
            _context.Translations.Remove(translation);
        }

        public IEnumerable<Translation> GetAll()
        {
            return _context.Translations;
        }

        public Translation GetById(int id)
        {
            return _context.Translations.FirstOrDefault(d => d.Id == id);
        }

        public void Update(Translation translation)
        {
            _context.Translations.Update(translation);
            _context.SaveChanges();
        }
    }
}
