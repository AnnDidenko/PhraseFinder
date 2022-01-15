using Phrase_Finder.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Infrastructure
{
    public interface IWordInfoService
    {
        Task<Dictionary<PartOfSpeech, string[]>> GetLemmas(string word);
        Task<Dictionary<WordInflectionForm, string[]>> GetWordInflections(string word);
    }
}
