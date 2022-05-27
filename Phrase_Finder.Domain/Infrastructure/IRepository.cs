using Phrase_Finder.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phrase_Finder.Domain.Infrastructure
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        Task Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
