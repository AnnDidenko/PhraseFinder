using Phrase_Finder.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Infrastructure
{
    public interface IWordInfoService
    {
        Task<string[]> GetLemmas(string word);
        Task<string[]> GetWordInflections(string word);
    }
}
