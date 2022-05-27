using Phrase_Finder.Domain.Entities;

namespace Phrase_Finder.Domain.Infrastructure
{
    public interface IDictionaryRepository: IRepository<Dictionary>
    {
        public Dictionary GetDictionaryByUserId(int id);
    }
}
