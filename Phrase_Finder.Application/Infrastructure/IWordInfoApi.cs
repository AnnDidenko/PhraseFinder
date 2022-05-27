using Phrase_Finder.Application.Models;
using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Infrastructure
{
    [BasePath("http://localhost:4449/api")]
    public interface IWordInfoApi
    {
        [Get("lemmas")]
        Task<Dictionary<object, string[]>> GetLemmas([Query] string word);

        [Get("inflections")]
        Task<Dictionary<object, string[]>> GetWordInflections([Query] string word);
    }
}
