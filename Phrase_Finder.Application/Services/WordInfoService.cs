using Phrase_Finder.Application.Infrastructure;
using Phrase_Finder.Application.Models;
using System.Collections.Generic;
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

        public async Task<Dictionary<PartOfSpeech, string[]>> GetLemmas(string word)
        {
            Dictionary<PartOfSpeech, string[]> lemma = await _wordInfoApi.GetLemmas(word);
            return lemma;
        }

        public async Task<Dictionary<WordInflectionForm, string[]>> GetWordInflections(string word)
        {
            Dictionary<WordInflectionForm, string[]> inflections = await _wordInfoApi.GetWordInflections(word);
            return inflections;
        }
    }
}
