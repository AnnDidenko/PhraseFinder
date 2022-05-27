using AutoMapper;
using Phrase_Finder.Application.Infrastructure;
using Phrase_Finder.Application.Models;
using Phrase_Finder.Domain.Entities;
using Phrase_Finder.Domain.Infrastructure;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Services
{
    public class DictionaryService: IDictionaryService
    {
        private IDictionaryRepository _dictionaryRepository;
        private ITranslationRepository _translationRepository;
        private IEnglishWordRepository _englishWordRepository;
        private ITranslationalWordRepository _translationalWordRepository;
        private IAuthService _authService;
        private IMapper _mapper;

        public DictionaryService(IDictionaryRepository dictionaryRepository,
                                 ITranslationRepository translationRepository,
                                 IEnglishWordRepository englishWordRepository,
                                 ITranslationalWordRepository translationalWordRepository,
                                 IAuthService authService,
                                 IMapper mapper)
        {
            _dictionaryRepository = dictionaryRepository;
            _englishWordRepository = englishWordRepository;
            _translationalWordRepository = translationalWordRepository;
            _translationRepository = translationRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task AddWordToDictionary(UserDto user, TranslationDto translation)
        {
            var dict = _dictionaryRepository.GetDictionaryByUserId(user.Id);
            if (dict == null)
            {
                await _dictionaryRepository.Add(_mapper.Map<Dictionary>
                                (new DictionaryDto { Name = "Personal dictionary", Topic = "All", UserId = user.Id }));
            }

            translation.DictionaryId = dict.Id;
            await _translationRepository.Add(_mapper.Map<Translation>(translation));
        }

        public async Task<DictionaryDto> GetDictionary(UserDto user)
        {
            var dict = _dictionaryRepository.GetDictionaryByUserId(user.Id);
            return _mapper.Map<DictionaryDto>(dict);
        }
    }
}
