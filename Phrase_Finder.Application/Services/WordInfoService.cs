using Phrase_Finder.Application.Infrastructure;
using Phrase_Finder.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Services
{
    public class WordInfoService : IWordInfoService
    {
        private readonly IWordInfoApi _wordInfoApi;

        public WordInfoService(IWordInfoApi wordInfoApi)
        {
            _wordInfoApi = wordInfoApi;
        }

        public async Task<string[]> GetLemmas(string word)
        {
            Dictionary<object, string[]> lemmas = await _wordInfoApi.GetLemmas(word);
            return lemmas.SelectMany(lemma => lemma.Value)
                         .Distinct().ToArray();
        }

        public async Task<string[]> GetWordInflections(string word)
        {
            Dictionary<object, string[]> inflections = await _wordInfoApi.GetWordInflections(word);
            return inflections.SelectMany(inflection => inflection.Value)
                              .Distinct().ToArray();
        }
    }
}
