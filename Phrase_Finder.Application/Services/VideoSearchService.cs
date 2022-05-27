using AutoMapper;
using Phrase_Finder.Application.Infrastructure;
using Phrase_Finder.Application.Models;
using Phrase_Finder.Domain.Entities;
using Phrase_Finder.Domain.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Services
{
    public class VideoSearchService : IVideoSearchService
    {
        private IWordInfoService _wordInfoService;
        private IVideosRepository _videoRepository;
        private IMapper _mapper;

        public VideoSearchService(IWordInfoService wordInfoService,
                             IVideosRepository videoRepository,
                             IMapper mapper)
        {
            _wordInfoService = wordInfoService;
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        public async Task<Dictionary<VideoDto, string[]>> Search(string[] words)
        {
            Dictionary<VideoDto, string[]> items = new Dictionary<VideoDto, string[]>();
            foreach(var word in words)
            {
                var inflections = await GetInflectionsFromSearchedWord(word.ToLower());
                Dictionary<VideoDto, string[]> searchedByWord;
                if (inflections.Length != 0)
                {
                    searchedByWord = SearchByInflections(inflections);
                }
                else
                {
                    searchedByWord = SearchByInflections(new[] { word });
                }
                foreach(var item in searchedByWord)
                {
                    if (!items.ContainsKey(item.Key))
                    {
                        items.Add(item.Key, item.Value);
                    }
                }
            }
            items.OrderBy(item => item.Value.Length);
            return items;
        }

        private async Task<string[]> GetInflectionsFromSearchedWord(string word)
        {
            List<string> allInflections = new List<string>();

            var lemmas = await _wordInfoService.GetLemmas(word);
            foreach(var lemma in lemmas)
            {
                var inflections = await _wordInfoService.GetWordInflections(lemma);
                allInflections.AddRange(inflections);
            }

            return allInflections.ToArray();
        }

        private Dictionary<VideoDto, string[]> SearchByInflections(string[] words)
        {
            Dictionary<string, List<VideoDto>> items = new Dictionary<string, List<VideoDto>>();

            for (int i = 0; i < words.Length; i++)
            {
                var searchedItems = _videoRepository
                                    .GetAllByWord(words[i]) 
                                    .ToList();

                var mappedItems = _mapper.Map<List<Video>, List<VideoDto>>(searchedItems);

                items.Add(words[i], mappedItems);
            }

            Dictionary<VideoDto, string[]> matchedItems = new Dictionary<VideoDto, string[]>();

            foreach (var keyValue in items)
            {
                foreach (var item in keyValue.Value)
                {
                    if (!matchedItems.ContainsKey(item))
                    {
                        matchedItems.Add(item, new string[] { keyValue.Key });
                    }
                    else
                    {
                        string[] previosWords = matchedItems[item];
                        matchedItems[item] = previosWords.Append(keyValue.Key).ToArray();
                    }
                }
            }

            return matchedItems;
        }
    }
}
